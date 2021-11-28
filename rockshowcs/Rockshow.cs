using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Streaming;
using Q42.HueApi.Streaming.Effects;
using Q42.HueApi.Streaming.Extensions;
using Q42.HueApi.Streaming.Models;

namespace rockshowcs
{
    class BasicLightInfo
    {
        string id;
        bool active;
        int brightness;
    }

    class Rockshow
    {
        private String bridgeIP = "";
        private String userID = "";
        private String clientKey = "";
        private bool red = true;

        private AudioHandler audioHandler = new AudioHandler();

        private EntertainmentLayer baseLayer;
        private double lightAdjustementFrequency = 0.1;

        private bool tempRecordingCheck = false;

        private CancellationTokenSource streamCancelSource;
        private CancellationTokenSource showCancelSource;
        private CancellationToken streamCancelToken;
        private CancellationToken showCancelToken;

        public void SetUserID( string id )
        {
            userID = id;
        }

        public void SetBridgeIP( string ip )
        {
            bridgeIP = ip;
        }

        public async void Connect()
        {
            StreamingHueClient client = new StreamingHueClient( bridgeIP, userID, clientKey );
            var allEntGroups = await client.LocalHueClient.GetEntertainmentGroups();
            var group = allEntGroups.FirstOrDefault();
            var streamingGroup = new StreamingGroup( group.Locations );

            streamCancelSource = new CancellationTokenSource();
            streamCancelToken = streamCancelSource.Token;
            await client.Connect( group.Id );
            client.AutoUpdate( streamingGroup, streamCancelToken );
            baseLayer = streamingGroup.GetNewLayer( isBaseLayer: true );
            baseLayer.SetState( streamCancelToken, new RGBColor( "FF0000" ), 1, TimeSpan.FromSeconds( 0.05 ) );
        }

        public async Task ResetLights()
        {
            streamCancelSource?.Cancel();
        }

        public async void StartShow()
        {
            showCancelSource = new CancellationTokenSource();
            showCancelToken = showCancelSource.Token;
            var task = baseLayer.IteratorEffect( showCancelToken, async ( current, cancel, t ) =>
            {
                RGBColor color;
                 if( red )
                     color = new RGBColor( 0, 0, 50 );
                 else
                     color = new RGBColor( 50, 0, 0 );

                 red = !red;
                 current.SetState( showCancelToken, color, brightness: 1, TimeSpan.FromSeconds( lightAdjustementFrequency ) );
             }, IteratorEffectMode.All, waitTime: () => { return TimeSpan.FromSeconds( lightAdjustementFrequency ); } );
        }

        public async void StopShow()
        {
            showCancelSource?.Cancel();
        }

        public void Playback()
        {
            if( tempRecordingCheck )
            {
                audioHandler.StopRecording();
                //audioHandler.StopPlaybackAudio();
            }
            else
            {
                audioHandler.StartRecording( showCancelToken );
                //audioHandler.PlaybackAudio();
            }
            tempRecordingCheck = !tempRecordingCheck;
        }

        public void ShowASIOPanel()
        {
            audioHandler.ShowASIOControlPanel();
        }

        public void StopAudio()
        {
            audioHandler.StopRecording();
            //audioHandler.StopPlaybackAudio();
        }
    }
}

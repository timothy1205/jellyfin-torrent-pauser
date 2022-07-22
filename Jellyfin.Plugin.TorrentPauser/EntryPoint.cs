using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jellyfin.Data.Entities;
using Jellyfin.Data.Events;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Authentication;
using MediaBrowser.Controller.Dto;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Controller.Session;
using MediaBrowser.Controller.Subtitles;
using MediaBrowser.Model.Entities;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.TorrentPauser
{
    public class EntryPoint : IServerEntryPoint
    {
        private readonly ISessionManager _sessionManager;
        private Qbittorrent _qbittorrent;

        public EntryPoint(
            ISessionManager sessionManager
            )
        {
            _sessionManager = sessionManager;
            _qbittorrent = new Qbittorrent();
        }

        public void Dispose()
        {
            _sessionManager.PlaybackStart -= OnPlaybackStart;
            _sessionManager.PlaybackStopped -= OnPlaybackStopped;
        }

        public Task RunAsync()
        {
            _sessionManager.PlaybackStart += OnPlaybackStart;
            _sessionManager.PlaybackStopped += OnPlaybackStopped;

            return Task.CompletedTask;
        }

        private async void OnPlaybackStart(object sender, PlaybackProgressEventArgs e)
        {
            // Limit
        }

        private async void OnPlaybackStopped(object sender, PlaybackStopEventArgs e)
        {
            // Unlimit
        }
    }
}

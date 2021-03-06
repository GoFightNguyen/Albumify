﻿using Albumify.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Albumify.Spotify.Models
{
    public class ArtistObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("images")]
        public List<ImageObject> Images { get; set; }

        public static explicit operator Artist(ArtistObject spotifyArtist)
        {
            var images = spotifyArtist.Images.ConvertAll(i => (Image)i).ToList();
            return new Artist
            {
                Images = images,
                Name = spotifyArtist.Name,
                ThirdPartyId = spotifyArtist.Id
            };
        }
    }
}
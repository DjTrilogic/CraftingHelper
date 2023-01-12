// <auto-generated />
//
// To parse this JSON data, add NuGet 'System.Text.Json' then do:
//
//    using CraftingHelper;
//
//    var config = Config.FromJson(jsonString);
#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603

namespace CraftingHelper.Config
{
    using System;
    using System.Collections.Generic;

    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;

    public partial class Config
    {
        [JsonPropertyName("settings")]
        public Settings Settings { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("config")]
        public ConfigElement[] ConfigConfig { get; set; }

        [JsonPropertyName("flow")]
        public Flow Flow { get; set; }

        [JsonPropertyName("states")]
        public States States { get; set; }

        [JsonPropertyName("results")]
        public Result[] Results { get; set; }

        [JsonPropertyName("items")]
        public object Items { get; set; }
    }

    public partial class ConfigElement
    {
        [JsonPropertyName("method")]
        public string[] Method { get; set; }

        [JsonPropertyName("mopts")]
        public object Mopts { get; set; }

        [JsonPropertyName("autopass")]
        public bool Autopass { get; set; }

        [JsonPropertyName("filters")]
        public Filter[] Filters { get; set; }

        [JsonPropertyName("vfilter")]
        public object[] Vfilter { get; set; }

        [JsonPropertyName("actions")]
        public Actions Actions { get; set; }
    }

    public partial class Actions
    {
        [JsonPropertyName("win")]
        public string Win { get; set; }

        [JsonPropertyName("win_route")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? WinRoute { get; set; }

        [JsonPropertyName("fail")]
        public string Fail { get; set; }

        [JsonPropertyName("fail_route")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? FailRoute { get; set; }
    }

    public partial class Filter
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("treshold")]
        public long? Treshold { get; set; }

        [JsonPropertyName("conds")]
        public Cond[] Conds { get; set; }
    }

    public partial class Cond
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("treshold")]
        public long Treshold { get; set; }

        [JsonPropertyName("max")]
        public object Max { get; set; }

        [JsonPropertyName("base")]
        public object Base { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("fmodpool")]
        public object Fmodpool { get; set; }

        [JsonPropertyName("eldritch")]
        public object Eldritch { get; set; }

        [JsonPropertyName("dominance")]
        public object Dominance { get; set; }

        [JsonPropertyName("mtypes")]
        public object Mtypes { get; set; }

        [JsonPropertyName("implicits")]
        public object Implicits { get; set; }

        [JsonPropertyName("rollable_implicits")]
        public long RollableImplicits { get; set; }

        [JsonPropertyName("cmodpool")]
        public object Cmodpool { get; set; }

        [JsonPropertyName("hmodpool")]
        public object Hmodpool { get; set; }

        [JsonPropertyName("maxaffgrp")]
        public Cmaxaffgrp Maxaffgrp { get; set; }

        [JsonPropertyName("is_rare")]
        public long IsRare { get; set; }

        [JsonPropertyName("is_fossil")]
        public long IsFossil { get; set; }

        [JsonPropertyName("is_craftable")]
        public long IsCraftable { get; set; }

        [JsonPropertyName("is_influenced")]
        public long IsInfluenced { get; set; }

        [JsonPropertyName("is_essence")]
        public long IsEssence { get; set; }

        [JsonPropertyName("is_catalyst")]
        public long IsCatalyst { get; set; }

        [JsonPropertyName("is_notable")]
        public long IsNotable { get; set; }

        [JsonPropertyName("unique_notable")]
        public long UniqueNotable { get; set; }

        [JsonPropertyName("iaffixes")]
        public object[] Iaffixes { get; set; }

        [JsonPropertyName("meta_flags")]
        public MetaFlags MetaFlags { get; set; }

        [JsonPropertyName("imprint")]
        public object Imprint { get; set; }

        [JsonPropertyName("enchant")]
        public string Enchant { get; set; }

        [JsonPropertyName("iaffbt")]
        public Cmaxaffgrp Iaffbt { get; set; }

        [JsonPropertyName("cmaxaffgrp")]
        public Cmaxaffgrp Cmaxaffgrp { get; set; }

        [JsonPropertyName("mgrpdata")]
        public object Mgrpdata { get; set; }

        [JsonPropertyName("affbymgrp")]
        public object Affbymgrp { get; set; }

        [JsonPropertyName("veiledmods")]
        public object Veiledmods { get; set; }
    }

    public partial class Cmaxaffgrp
    {
        [JsonPropertyName("prefix")]
        public long Prefix { get; set; }

        [JsonPropertyName("suffix")]
        public long Suffix { get; set; }
    }

    public partial class MetaFlags
    {
    }

    public partial class Flow
    {
        [JsonPropertyName("split")]
        public long Split { get; set; }

        [JsonPropertyName("into")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Into { get; set; }

        [JsonPropertyName("layout")]
        public System.Collections.Generic.Dictionary<string, Layout> Layout { get; set; }
    }

    public partial class Layout
    {
        [JsonPropertyName("w")]
        public string W { get; set; }

        [JsonPropertyName("f")]
        public string F { get; set; }
    }

    public partial class Result
    {
        [JsonPropertyName("cnt")]
        public long Cnt { get; set; }

        [JsonPropertyName("pass")]
        public long Pass { get; set; }
    }

    public partial class Settings
    {
        [JsonPropertyName("bgroup")]
        public long Bgroup { get; set; }

        [JsonPropertyName("base")]
        public long Base { get; set; }

        [JsonPropertyName("bitem")]
        public long Bitem { get; set; }

        [JsonPropertyName("ilvl")]
        public long Ilvl { get; set; }

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("influences")]
        public long[] Influences { get; set; }

        [JsonPropertyName("quality")]
        public long Quality { get; set; }
    }

    public partial class States
    {
        [JsonPropertyName("init")]
        public Current Init { get; set; }

        [JsonPropertyName("current")]
        public Current Current { get; set; }

        [JsonPropertyName("states")]
        public Current[] StatesStates { get; set; }
    }

    public partial class Current
    {
        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonPropertyName("dominance")]
        public object Dominance { get; set; }

        [JsonPropertyName("influences")]
        public long[] Influences { get; set; }

        [JsonPropertyName("meta")]
        public object Meta { get; set; }
    }

    public partial class Config
    {
        public static Config FromJson(string json) => JsonSerializer.Deserialize<Config>(json, CraftingHelper.Config.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Config self) => JsonSerializer.Serialize(self, CraftingHelper.Config.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
            {
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            },
        };
    }

    internal class ParseStringConverter : JsonConverter<long>
    {
        public override bool CanConvert(Type t) => t == typeof(long);

        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;
        public DateOnlyConverter() : this(null) { }

        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null) { }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string? _dateTimeFormat;
        private CultureInfo? _culture;

        public DateTimeStyles DateTimeStyles
        {
            get => _dateTimeStyles;
            set => _dateTimeStyles = value;
        }

        public string? DateTimeFormat
        {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
        }

        public CultureInfo Culture
        {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            string text;


            if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
            {
                value = value.ToUniversalTime();
            }

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                }
            }
            else
            {
                return default(DateTimeOffset);
            }
        }


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
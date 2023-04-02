namespace ScribanSourceGeneratorDemo;

// SourceGenerator と partial class から生成します

[ScribanSourceGenerator.ClassMember("""
    {{
    $types = ["bool","byte","sbyte","short","ushort","int","uint","long","ulong","float","double","DateTime","DateTimeOffset","TimeSpan"]
    for $t in $types
    ~}}
        public static bool TryParse(this string s, out {{$t}} x) => {{$t}}.TryParse(s, out x);
    {{ end }}
    """)]
static partial class ScribanGenDemo1
{ }

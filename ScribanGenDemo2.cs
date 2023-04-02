namespace ScribanSourceGeneratorDemo;

// SourceGenerator と partial class から生成します

[ScribanSourceGenerator.ClassMember("""
    {{
    func get_words(max,words...);
      $s1 = "";
      for $i in 1..max
        $s2 = "";
        for $w in words
          $s2 += $w 

          # Do not join index at the end.
          if !for.last; $s2 += $i; end
        end

        $s1 += $s2
        if !for.last
            $s1 += ", "
        end
      end
      ret $s1;
    end
    -}}
    {{ for $i in 2..4 ~}}
        public static async Task<({{ get_words $i "T" "" }})> WhenAll<{{ get_words $i "T" "" }}>({{ get_words $i "Task<T" "> task" "" }})
        {
            await Task.WhenAll({{ get_words $i "task" "" }});
            return ({{ get_words $i "task" ".Result" }});
        }
    {{ end }}
    """)]
static partial class ScribanGenDemo2
{ }

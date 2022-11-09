using System.Text;

namespace Kogane
{
    public static class JsonFormatter
    {
        public static string ToReadable( string json )
        {
            if ( string.IsNullOrEmpty( json ) ) return json;

            var i          = 0;
            var indent     = 0;
            var quoteCount = 0;
            var position   = -1;
            var sb         = new StringBuilder();
            var lastIndex  = 0;

            while ( true )
            {
                if ( i > 0 && json[ i ] == '"' && json[ i - 1 ] != '\\' ) quoteCount++;

                if ( quoteCount % 2 == 0 )
                {
                    if ( json[ i ] == '{' || json[ i ] == '[' )
                    {
                        indent++;
                        position = 1;
                    }
                    else if ( json[ i ] == '}' || json[ i ] == ']' )
                    {
                        indent--;
                        position = 0;
                    }
                    else if ( json.Length > i && json[ i ] == ',' && json[ i + 1 ] == '"' )
                    {
                        position = 1;
                    }

                    if ( position >= 0 )
                    {
                        sb.AppendLine( json.Substring( lastIndex, i + position - lastIndex ) );
                        sb.Append( new string( ' ', indent * 4 ) );
                        lastIndex = i + position;
                        position  = -1;
                    }
                }

                i++;

                if ( json.Length <= i )
                {
                    sb.Append( json.Substring( lastIndex ) );
                    break;
                }
            }

            return sb.ToString();
        }
    }
}
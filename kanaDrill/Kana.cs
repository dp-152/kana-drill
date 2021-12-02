using System;
using System.Collections.Generic;
using System.Linq;

namespace kanaDrill
{
    class Kana
    {
        class KanaData
        {
            public byte index { get; set; }
            public string hira { get; set; }
            public string kata { get; set; }
            public string roma { get; set; }
            public byte last { get; set; }
        }
        static KanaData[] items = {
        
        //A row
        new KanaData { index=0, hira="あ", kata="ア", roma="a" },
        new KanaData { index=1, hira="い", kata="イ", roma="i" },
        new KanaData { index=2, hira="う", kata="ウ", roma="u" },
        new KanaData { index=3, hira="え", kata="エ", roma="e" },
        new KanaData { index=4, hira="お", kata="オ", roma="o" },

        //KA row
        new KanaData { index=5, hira="か", kata="カ", roma="ka" },
        new KanaData { index=6, hira="き", kata="キ", roma="ki" },
        new KanaData { index=7, hira="く", kata="ク", roma="ku" },
        new KanaData { index=8, hira="け", kata="ケ", roma="ke" },
        new KanaData { index=9, hira="こ", kata="コ", roma="ko" },

        //SA row
        new KanaData { index=10, hira="さ", kata="サ", roma="sa" },
        new KanaData { index=11, hira="し", kata="シ", roma="shi" },
        new KanaData { index=12, hira="す", kata="ス", roma="su" },
        new KanaData { index=13, hira="せ", kata="セ", roma="se" },
        new KanaData { index=14, hira="そ", kata="ソ", roma="so" },

        //TA row
        new KanaData { index=15, hira="た", kata="タ", roma="ta" },
        new KanaData { index=16, hira="ち", kata="チ", roma="chi" },
        new KanaData { index=17, hira="つ", kata="ツ", roma="tsu" },
        new KanaData { index=18, hira="て", kata="テ", roma="te" },
        new KanaData { index=19, hira="と", kata="ト", roma="to" },

        //NA row
        new KanaData { index=20, hira="な", kata="ナ", roma="na" },
        new KanaData { index=21, hira="に", kata="ニ", roma="ni" },
        new KanaData { index=22, hira="ぬ", kata="ヌ", roma="nu" },
        new KanaData { index=23, hira="ね", kata="ネ", roma="ne" },
        new KanaData { index=24, hira="の", kata="ノ", roma="no" },

        //HA row
        new KanaData { index=25, hira="は", kata="ハ", roma="ha" },
        new KanaData { index=26, hira="ひ", kata="ヒ", roma="hi" },
        new KanaData { index=27, hira="ふ", kata="フ", roma="fu" },
        new KanaData { index=28, hira="へ", kata="ヘ", roma="he" },
        new KanaData { index=29, hira="ほ", kata="ホ", roma="ho" },

        //MA row
        new KanaData { index=30, hira="ま", kata="マ", roma="ma" },
        new KanaData { index=31, hira="み", kata="ミ", roma="mi" },
        new KanaData { index=32, hira="む", kata="ム", roma="mu" },
        new KanaData { index=33, hira="め", kata="メ", roma="me" },
        new KanaData { index=34, hira="も", kata="モ", roma="mo" },

        //YA row
        new KanaData { index=35, hira="や", kata="ヤ", roma="ya" },
        new KanaData { index=36, hira="ゆ", kata="ユ", roma="yu" },
        new KanaData { index=37, hira="よ", kata="ヨ", roma="yo" },

        //RA row
        new KanaData { index=38, hira="ら", kata="ラ", roma="ra" },
        new KanaData { index=39, hira="り", kata="リ", roma="ri" },
        new KanaData { index=40, hira="る", kata="ル", roma="ru" },
        new KanaData { index=41, hira="れ", kata="レ", roma="re" },
        new KanaData { index=42, hira="ろ", kata="ロ", roma="ro" },

        //WA row
        new KanaData { index=43, hira="わ", kata="ワ", roma="wa" },
        new KanaData { index=44, hira="を", kata=null, roma="wo" },

        //N row
        new KanaData { index=45, hira="ん", kata="ン", roma="n" },

        //***********************************************//

        //KYA row
        new KanaData { index=46, hira="きゃ", kata="キャ", roma="kya" },
        new KanaData { index=47, hira="きゅ", kata="キュ", roma="kyu" },
        new KanaData { index=48, hira="きょ", kata="キョ", roma="kyo" },

        //SHA row
        new KanaData { index=49, hira="しゃ", kata="シャ", roma="sha" },
        new KanaData { index=50, hira="しゅ", kata="シュ", roma="shu" },
        new KanaData { index=51, hira="しょ", kata="ショ", roma="sho" },

        //CHA row
        new KanaData { index=52, hira="ちゃ", kata="チャ", roma="cha" },
        new KanaData { index=53, hira="ちゅ", kata="チュ", roma="chu" },
        new KanaData { index=54, hira="ちょ", kata="チョ", roma="cho" },

        //NYA row
        new KanaData { index=55, hira="にゃ", kata="ニャ", roma="nya" },
        new KanaData { index=56, hira="にゅ", kata="ニュ", roma="nyu" },
        new KanaData { index=57, hira="にょ", kata="ニョ", roma="nyo" },

        //HYA row
        new KanaData { index=58, hira="ひゃ", kata="ヒャ", roma="hya" },
        new KanaData { index=59, hira="ひゅ", kata="ヒュ", roma="hyu" },
        new KanaData { index=60, hira="ひょ", kata="ヒョ", roma="hyo" },

        //MYA row
        new KanaData { index=61, hira="みゃ", kata="ミャ", roma="mya" },
        new KanaData { index=62, hira="みゅ", kata="ミュ", roma="myu" },
        new KanaData { index=63, hira="みょ", kata="ミョ", roma="myo" },

        //RYA row
        new KanaData { index=64, hira="りゃ", kata="リャ", roma="rya" },
        new KanaData { index=65, hira="りゅ", kata="リュ", roma="ryu" },
        new KanaData { index=66, hira="りょ", kata="リョ", roma="ryo" },

        //***********************************************//

        //GA row
        new KanaData { index=67, hira="が", kata="ガ", roma="ga" },
        new KanaData { index=68, hira="ぎ", kata="ギ", roma="gi" },
        new KanaData { index=69, hira="ぐ", kata="グ", roma="gu" },
        new KanaData { index=70, hira="げ", kata="ゲ", roma="ge" },
        new KanaData { index=71, hira="ご", kata="ゴ", roma="go" },

        //ZA row
        new KanaData { index=72, hira="ざ", kata="ザ", roma="za" },
        new KanaData { index=73, hira="じ", kata="ジ", roma="ji" },
        new KanaData { index=74, hira="ず", kata="ズ", roma="zu" },
        new KanaData { index=75, hira="ぜ", kata="ゼ", roma="ze" },
        new KanaData { index=76, hira="ぞ", kata="ゾ", roma="zo" },

        //DA row
        new KanaData { index=77, hira="だ", kata="ダ", roma="da" },
        new KanaData { index=78, hira="ぢ", kata="ヂ", roma="di" },
        new KanaData { index=79, hira="づ", kata="ヅ", roma="du" },
        new KanaData { index=80, hira="で", kata="デ", roma="de" },
        new KanaData { index=81, hira="ど", kata="ド", roma="do" },

        //BA row
        new KanaData { index=82, hira="ば", kata="バ", roma="ba" },
        new KanaData { index=83, hira="び", kata="ビ", roma="bi" },
        new KanaData { index=84, hira="ぶ", kata="ブ", roma="bu" },
        new KanaData { index=85, hira="べ", kata="ベ", roma="be" },
        new KanaData { index=86, hira="ぼ", kata="ボ", roma="bo" },

        //PA row
        new KanaData { index=87, hira="ぱ", kata="パ", roma="pa" },
        new KanaData { index=88, hira="ぴ", kata="ピ", roma="pi" },
        new KanaData { index=89, hira="ぷ", kata="プ", roma="pu" },
        new KanaData { index=90, hira="ぺ", kata="ペ", roma="pe" },
        new KanaData { index=91, hira="ぽ", kata="ポ", roma="po" },

        //***********************************************//

        //GYA row
        new KanaData { index=92, hira="ぎゃ", kata="ギャ", roma="gya" },
        new KanaData { index=93, hira="ぎゅ", kata="ギュ", roma="gyu" },
        new KanaData { index=94, hira="ぎょ", kata="ギョ", roma="gyo" },

        //JA row
        new KanaData { index=95, hira="じゃ", kata="ジャ", roma="ja" },
        new KanaData { index=96, hira="じゅ", kata="ジュ", roma="ju" },
        new KanaData { index=97, hira="じょ", kata="ジョ", roma="jo" },

        //BYA row
        new KanaData { index=98, hira="びゃ", kata="ビャ", roma="bya" },
        new KanaData { index=99, hira="びゅ", kata="ビュ", roma="byu" },
        new KanaData { index=100, hira="びょ", kata="ビョ", roma="byo" },

        //PYA row
        new KanaData { index=101, hira="ぴゃ", kata="ピャ", roma="pya" },
        new KanaData { index=102, hira="ぴゅ", kata="ピュ", roma="pyu" },
        new KanaData { index=103, hira="ぴょ", kata="ピョ", roma="pyo" },
        };

        int[] hscore = new int[items.Length];
        int[] kscore = new int[items.Length];
        Stack<KanaData> kanaStack = new Stack<KanaData>();
        Stack<string> hiraganaStack = new Stack<string>();
        Stack<string> katakanaStack = new Stack<string>();
        Stack<string> romajiStack = new Stack<string>();

        private void reStack()
        {
            if (kanaStack.Count == 0 && romajiStack.Count == 0)
            {
                Random _random = new Random();
                kanaStack = new Stack<KanaData>(items.OrderBy(r => _random.Next()));
                foreach (KanaData kana in kanaStack)
                {
                    hiraganaStack.Push(kana.hira);
                    katakanaStack.Push(kana.kata);
                    romajiStack.Push(kana.roma);
                }
                kanaStack.Clear();
            }
        }
        public void pullKana(ref string currHira, ref string currKata, ref string currRoma)
        {            
            reStack();
            currHira = hiraganaStack.Pop();
            currKata = katakanaStack.Pop();
            currRoma = romajiStack.Pop();

        }
    }
}

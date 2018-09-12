﻿namespace PragmaticSegmenterNet.Tests.Unit
{
    using Xunit;

    public class JapaneseLanguageTests
    {
        [Fact]
        public void SimplePeriodToEndSentence001()
        {
            var result = Segmenter.Segment("これはペンです。それはマーカーです。", Language.Japanese);
            Assert.Equal(new[] { "これはペンです。", "それはマーカーです。" }, result);
        }

        [Fact]
        public void QuestionMarkToEndSentence002()
        {
            var result = Segmenter.Segment("それは何ですか？ペンですか？", Language.Japanese);
            Assert.Equal(new[] { "それは何ですか？", "ペンですか？" }, result);
        }

        [Fact]
        public void ExclamationPointToEndSentence003()
        {
            var result = Segmenter.Segment("良かったね！すごい！", Language.Japanese);
            Assert.Equal(new[] { "良かったね！", "すごい！" }, result);
        }

        [Fact]
        public void Quotation004()
        {
            var result = Segmenter.Segment("自民党税制調査会の幹部は、「引き下げ幅は３．２９％以上を目指すことになる」と指摘していて、今後、公明党と合意したうえで、３０日に決定する与党税制改正大綱に盛り込むことにしています。２％台後半を目指すとする方向で最終調整に入りました。", Language.Japanese);
            Assert.Equal(new[] { "自民党税制調査会の幹部は、「引き下げ幅は３．２９％以上を目指すことになる」と指摘していて、今後、公明党と合意したうえで、３０日に決定する与党税制改正大綱に盛り込むことにしています。", "２％台後半を目指すとする方向で最終調整に入りました。" }, result);
        }

        [Fact]
        public void ErrantNewlinesInTheMiddleOfSentences005()
        {
            var result = Segmenter.Segment("これは父の\n家です。", Language.Japanese);
            Assert.Equal(new[] { "これは父の家です。" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("これは山です \nこれは山です \nこれは山です（「これは山です」） \nこれは山です（これは山です「これは山です」）これは山です・これは山です、これは山です。 \nこれは山です（これは山です。これは山です）。これは山です、これは山です、これは山です、これは山です（これは山です。これは山です）これは山です、これは山です、これは山です「これは山です」これは山です（これは山です：0円）これは山です。 \n1.）これは山です、これは山です（これは山です、これは山です6円（※1））これは山です。 \n※1　これは山です。 \n2.）これは山です、これは山です、これは山です、これは山です。 \n3.）これは山です、これは山です・これは山です、これは山です、これは山です、これは山です（これは山です「これは山です」）これは山です、これは山です、これは山です、これは山です。 \n4.）これは山です、これは山です（これは山です、これは山です、これは山です。これは山です）これは山です、これは山です（これは山です、これは山です）。 \nこれは山です、これは山です、これは山です、これは山です、これは山です（者）これは山です。 \n(1) 「これは山です」（これは山です：0円）　（※1） \n① これは山です", Language.Japanese);
            Assert.Equal(new[] { "これは山です", "これは山です", "これは山です（「これは山です」）", "これは山です（これは山です「これは山です」）これは山です・これは山です、これは山です。", "これは山です（これは山です。これは山です）。", "これは山です、これは山です、これは山です、これは山です（これは山です。これは山です）これは山です、これは山です、これは山です「これは山です」これは山です（これは山です：0円）これは山です。", "1.）これは山です、これは山です（これは山です、これは山です6円（※1））これは山です。", "※1　これは山です。", "2.）これは山です、これは山です、これは山です、これは山です。", "3.）これは山です、これは山です・これは山です、これは山です、これは山です、これは山です（これは山です「これは山です」）これは山です、これは山です、これは山です、これは山です。", "4.）これは山です、これは山です（これは山です、これは山です、これは山です。これは山です）これは山です、これは山です（これは山です、これは山です）。", "これは山です、これは山です、これは山です、これは山です、これは山です（者）これは山です。", "(1) 「これは山です」（これは山です：0円）　（※1）", "① これは山です" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("フフーの\n主たる債務", Language.Japanese);
            Assert.Equal(new[] { "フフーの主たる債務" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("これは山です \nこれは山です \nこれは山です（「これは山です」） \nこれは山です（これは山です「これは山です」）これは山です・これは山です、これは山です． \nこれは山です（これは山です．これは山です）．これは山です、これは山です、これは山です、これは山です（これは山です．これは山です）これは山です、これは山です、これは山です「これは山です」これは山です（これは山です：0円）これは山です． \n1.）これは山です、これは山です（これは山です、これは山です6円（※1））これは山です． \n※1　これは山です． \n2.）これは山です、これは山です、これは山です、これは山です． \n3.）これは山です、これは山です・これは山です、これは山です、これは山です、これは山です（これは山です「これは山です」）これは山です、これは山です、これは山です、これは山です． \n4.）これは山です、これは山です（これは山です、これは山です、これは山です．これは山です）これは山です、これは山です（これは山です、これは山です）． \nこれは山です、これは山です、これは山です、これは山です、これは山です（者）これは山です． \n(1) 「これは山です」（これは山です：0円）　（※1） \n① これは山です", Language.Japanese);
            Assert.Equal(new[] { "これは山です", "これは山です", "これは山です（「これは山です」）", "これは山です（これは山です「これは山です」）これは山です・これは山です、これは山です．", "これは山です（これは山です．これは山です）．", "これは山です、これは山です、これは山です、これは山です（これは山です．これは山です）これは山です、これは山です、これは山です「これは山です」これは山です（これは山です：0円）これは山です．", "1.）これは山です、これは山です（これは山です、これは山です6円（※1））これは山です．", "※1　これは山です．", "2.）これは山です、これは山です、これは山です、これは山です．", "3.）これは山です、これは山です・これは山です、これは山です、これは山です、これは山です（これは山です「これは山です」）これは山です、これは山です、これは山です、これは山です．", "4.）これは山です、これは山です（これは山です、これは山です、これは山です．これは山です）これは山です、これは山です（これは山です、これは山です）．", "これは山です、これは山です、これは山です、これは山です、これは山です（者）これは山です．", "(1) 「これは山です」（これは山です：0円）　（※1）", "① これは山です" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment(
                "これは山です \nこれは山です \nこれは山です（「これは山です」） \nこれは山です（これは山です「これは山です」）これは山です・これは山です、これは山です！ \nこれは山です（これは山です！これは山です）！これは山です、これは山です、これは山です、これは山です（これは山です！これは山です）これは山です、これは山です、これは山です「これは山です」これは山です（これは山です：0円）これは山です！ \n1.）これは山です、これは山です（これは山です、これは山です6円（※1））これは山です！ \n※1　これは山です！ \n2.）これは山です、これは山です、これは山です、これは山です！ \n3.）これは山です、これは山です・これは山です、これは山です、これは山です、これは山です（これは山です「これは山です」）これは山です、これは山です、これは山です、これは山です！ \n4.）これは山です、これは山です（これは山です、これは山です、これは山です！これは山です）これは山です、これは山です（これは山です、これは山です）！ \nこれは山です、これは山です、これは山です、これは山です、これは山です（者）これは山です！ \n(1) 「これは山です」（これは山です：0円）　（※1） \n① これは山です",
                Language.Japanese);
            Assert.Equal(new[] { "これは山です", "これは山です", "これは山です（「これは山です」）", "これは山です（これは山です「これは山です」）これは山です・これは山です、これは山です！", "これは山です（これは山です！これは山です）！", "これは山です、これは山です、これは山です、これは山です（これは山です！これは山です）これは山です、これは山です、これは山です「これは山です」これは山です（これは山です：0円）これは山です！", "1.）これは山です、これは山です（これは山です、これは山です6円（※1））これは山です！", "※1　これは山です！", "2.）これは山です、これは山です、これは山です、これは山です！", "3.）これは山です、これは山です・これは山です、これは山です、これは山です、これは山です（これは山です「これは山です」）これは山です、これは山です、これは山です、これは山です！", "4.）これは山です、これは山です（これは山です、これは山です、これは山です！これは山です）これは山です、これは山です（これは山です、これは山です）！", "これは山です、これは山です、これは山です、これは山です、これは山です（者）これは山です！", "(1) 「これは山です」（これは山です：0円）　（※1）", "① これは山です" }, result);
        }
    }
}

using Entities.Concrete;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public static class NestExtensions
{
    public static QueryContainer BuildMultiMatchQuery<T>(string queryValue) where T : class
    {
        var fields = typeof(T).GetProperties().Select(p => p.Name.ToLower()).ToArray();

        return new QueryContainerDescriptor<T>()
            .MultiMatch(c => c
                .Type(TextQueryType.Phrase)
                .Fields(f => f.Fields(fields)).Lenient().Query(queryValue));
    }
    public static List<IndexPosts> GetSampleData()
    {
        var list = new List<IndexPosts>
        {
            new() {Id = "38d61273-8f4e-431c-a0bb-3de2fbbf8757", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "1", AuthorName = "Libre Texts"},  PostName = "Eşeyli Üreme Nedir?", PostDescription = "Eşeyli üreme ökaryotik hücrelerinden oluşumundan sonra ortaya çıkan evrimsel bir yeniliktir. Çoğu ökaryotun eşeyli üremesi gerçeği, evrimsel bir başarının göstergesidir. Bu durumun bazı dezavantajları olduğu kanıtlansa da çoğu ökaryot için üremenin tek yolu eşeyli üremedir.İlk bakışta, eşeysiz üreme eşeyli üremeden daha avantajlı gibi görünebilir." },
            new() {Id = "6d288857-34e4-417f-8a22-e0c7575972b5", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "2", AuthorName = "Alper Kaan Selçukoğlu"}, PostName = "Çiğdeci (Acridotheres tristis)", PostDescription = " Asya'ya özgü bir kuş olan Çiğdeci, güçlü bir bölgesel içgüdüye sahip, omnivor bir ormanlık kuştur; ancak kentsel ortamlara da son derece iyi adapte olmuştur. Çiğdecilerin yaşam alanı o kadar hızlı artmaktadır ki, IUCN Türlerin Hayatta Kalması Komisyonu, 2000 yılında bu kuşu dünyanın en istilacı türlerinden biri ve 'Dünyanın En Kötü İstilacı 100 Türü' arasında listelenen yalnızca üç kuştan biri olarak ilan etmiştir ve biyolojik çeşitlilik, tarım ve insan çıkarları için bir tehdit olarak görmüştür. Tür, 2008 yılında Avustralya'da 'En Önemli Zararlı' olarak adlandırılmıştır ve bölgenin ekosistemleri için ciddi bir tehdit oluşturmaktadır..."},
            new() {Id = "9dc521a4-3486-4c6c-b769-8bdafcc4563d", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "3", AuthorName = "Yasin Tuna Kurşunlu"}, PostName = "Hayvanlarda Zeka Kıyaslaması: Zeka Farkını Anlamak İçin Beyin Büyüklüğü Kullanılabilir mi?", PostDescription = "Türümüzün davranışsal nitelikleriyle diğer türlerinkiler karşılaştırıldığında, göze bir devamsızlık çarpar. Bu davranışsal devamsızlık, kendini başta teknoloji, kültür, dil ve sanat olmak üzere çeşitli bağlamlarında gösterir. Davranışsal ayrıksılığımızın kaynağı olan bilişsel altyapımız, zekasıyla en çok öne çıkan türler söz konusu olduğunda bile hayret vericidir..." },
            new() {Id = "b9044bf7-6917-4521-9b1b-f737a05965f9", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "4", AuthorName = "Leman Zeynep Bakkal"}, PostName = "Ezilme Sendromu Nedir? Crush Sendromu, Afetzede İçin Neden Önemlidir?", PostDescription = "Crush Sendromu (veya Türkçe adıyla 'Ezilme Sendromu'), iskelet kaslarının ezilmesi sonucunda yaşanan majör şok ve akut böbrek yetmezliği nedeniyle oluşan, deprem başta olmak üzere doğal afet vb. durumlar sonrasında hasarlanmış kas dokusundan açığa çıkan toksinlerin vücuda dağılmasına bağlı olarak gelişen bir sendromdur.."},
            new() {Id = "abc6caf0-6c60-4e9e-93d2-2f53fbe941e2", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "5", AuthorName = "Deha Kaykı" }, PostName = "Zehir Bulunduran Dinozorlar Var Mıydı?", PostDescription = " Zehir, doğadaki canlıların kendini korumak ya da avlanmak amacıyla evrimleştirdikleri önemli bir mekanizmadır. Bugün doğada bulunan pek çok canlı grubunda zehirli/zehirci özellik gözlemlenebilmektedir. ..." },
            new() {Id = "7b0636fd-42ca-4435-a9ff-bebef6a40fda", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "6", AuthorName = "Libre Texts" }, PostName = "Pasif Taşıma Nedir? Hücre Zarından Enerji Harcamadan Madde Geçişi Mümkün mü?", PostDescription = "Hücre zarları, belirli maddelerin hücreye girmesine ve çıkmasına izin verirken zararlı maddelerin girmesini ve gerekli maddelerin dışarı çıkmasını engellemelidir. Başka bir deyişle hücre zarları seçici geçirgendir; bazı maddelerin geçmesine izin verirken diğerlerinin geçmesine izin vermezler. Bu seçiciliği kaybederlerse, hücre artık hayatını sürdüremez ve ölür..." },
            new() {Id = "b7666135-d20b-4a52-98f2-87023d4c2bdb", CreatedDate = DateTime.Now,  IndexAuthor = new() { Id = "7", AuthorName = "Nuray Mustafazadə" }, PostName = "Psikolojik İlk Yardım Nedir? Travmatik Olaylar Yaşayan İnsanlara Nasıl Yaklaşmalısınız?", PostDescription = "Hepimizin daha önce duyduğu 'ilk yardım'' terimi genelde 'Fiziksel İlk Yardım''dan bahsederken kullanılır. Ancak travmatik olaylar yaşayan insanlar, aynı zamanda 'Psikolojik İlk Yardım'a da ihtiyaç duyabilir. Fiziksel İlk Yardım, bedensel bir yaralanmadan kaynaklanan fiziksel rahatsızlığı azaltmak için kullanılırken Psikolojik İlk Yardım, yüksek strese maruz kalan kişilerin yaşadığı acı verici duygu ve tepkileri azaltmak için kullanılır." },
        };
        return list;
    }
}

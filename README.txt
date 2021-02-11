Unique ID:
# Öncelik	
### Tarihe göre işlem sırası
## Alternatifler
## İşlem içi iş emri sırası
### Süre

Öncelikler: 
Is emirleri	ID	Islemler
BobinTaşı	1	Yükleme
Gömlek Tak	2	Yükleme
Fırın Tak	3	Yükleme 
Fırın Çıkart	4	Tavlama Bitim
S. Çanı tak	5	Tavlama Bitim
S. Çanı çıkart	6	Tavlama Bitim
Gömlek Çıkart	7	Kaide Boşalt
Bobin Taşı	8	Kaide Boşalt

Tarihe göre işlem sırası: 
Yukaridaki uc islem icin elimizdeki tum listede kaçıncı Yükleme, Tavlama bitimi yada kaide boşaltma olduğunu gösterir.
Ornek: elimizdeki 5. İslem yuklemeyse, bobin tasi, gomlek tak, firin tak is emirlerinin id’leri soyle olur:
1005...., 2005...., 3005....
ONEMLI: Tarihe gore islem sirasi bir tane olmali. 1005 ile baslayan 5. yukleme islemi bir tanedir. H2 ve HNX'tekiler hep ardisik olarak gitmeli.

Alternatifler:
Simdilik sadece 1. Ileride ayni islem icin baska alternatiflerin olmasi durumunda gecerli olacak.
İşlem içi iş emri sırası:
Takip edilmesi gereken is emri sirasi. Bir islem tekrarlanacaksa kacinci tekrar oldugunu da gosterir. 
Ornek elimizdeki 11. İslem yuklemeyse ve 3 bobin tasinacaksa, 10110101... , 10110102... , 10110103..., 20110104.., 30110105... diye devam eder. 

Süre:
Son 3 hane gerekli surenin (dakika olarak) 10 katini ifade eder. 2.5 dakika suren bir isin son 3 hanesi 025’tir. 

Skor Hesaplama (skorhesapla metodu):
ID’deki onceliklere gore Islemlerin onemi Yukleme, Tavlama Bitim, Kaide bosalt seklinde giderken, islem ici is emirlerinin onemi artan sirayla gider (firin tak bobin tasi’dan onemlidir, cunku islem icinde son emrin onemi arttirilarak cevrimlerin kisalmasi saglanir). Bu nedenle onem sirasi { 3, 2, 1, 6, 5, 4, 8, 7 } seklinde gitmektedir. Bunlara simdilik sirasiyla { 40, 39, 38, 16, 15, 14, 2, 1 } puan verildi.
Ayrica sure’si kisa olan isler onceliklendirilmektedir.

Onculerin Tamamlandigini Kontrol Etmek: (onculertamam metodu)
Is emrinin ID’sinde islem dedigimiz <Tarihe göre işlem sırası+Alternatifler> kismi anliniyor. Sonra sirasi ID’deki <İşlem içi iş emri sırası>ndan aliniyor. En son olarak ID sonundaki tipi “HN” ya da “H2” olarak geliyor. Eger tamamlanan is listesinde ayni islem ve tipine sahip bir is varsa ve sirasi bir eksikse, oncusu isin yapildigi anlasiliyor.

Üretimden belirtilen istekler:
Yükleme önceliklidir. Yüklenecek boş kaide olduğu sürece önce yükleme iş emri gelmeli. 
Boşta kaide olduğu durumda Yükleme işinin yapılması istenmektedir o nedenle boşta kaide olduğu durumda vinçlere atanacak işler Bobin taşı Gömlek Tak ve Fırın Tak işleri olmalıdır 
Yükleme işleri bittikten sonra Diğer işler yapılmalıdır o işlerde de Tav bitim işleri önceliklidir
6’yi yapan vinc, 7’yi ve 8’i de yapmali.
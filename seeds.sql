-- _Member_ tablosuna veri ekleme
INSERT INTO _Member_ (Name, Surname, Email, Gender, Birthday) VALUES
('Ahmet', 'Yılmaz', 'ahmet.yilmaz@example.com', 'Erkek', '1990-01-15'),
('Ayşe', 'Kara', 'ayse.kara@example.com', 'Kadın', '1985-02-20'),
('Mehmet', 'Çelik', 'mehmet.celik@example.com', 'Erkek', '1992-03-10'),
('Fatma', 'Demir', 'fatma.demir@example.com', 'Kadın', '1988-04-25'),
('Emre', 'Şahin', 'emre.sahin@example.com', 'Erkek', '1995-05-30'),
('Zeynep', 'Koç', 'zeynep.koc@example.com', 'Kadın', '1991-06-15'),
('Ali', 'Öztürk', 'ali.ozturk@example.com', 'Erkek', '1993-07-20'),
('Hülya', 'Yıldırım', 'hulya.yildirim@example.com', 'Kadın', '1987-08-05'),
('Mustafa', 'Arslan', 'mustafa.arslan@example.com', 'Erkek', '1996-09-10'),
('Elif', 'Güneş', 'elif.gunes@example.com', 'Kadın', '1989-10-25'),
('Kemal', 'Bozkurt', 'kemal.bozkurt@example.com', 'Erkek', '1984-11-15'),
('Sibel', 'Aydın', 'sibel.aydin@example.com', 'Kadın', '1997-12-20'),
('Burak', 'Kılıç', 'burak.kilic@example.com', 'Erkek', '1991-01-10'),
('Nazan', 'Aksoy', 'nazan.aksoy@example.com', 'Kadın', '1986-02-25'),
('Serkan', 'Erdoğan', 'serkan.erdogan@example.com', 'Erkek', '1993-03-15'),
('Deniz', 'Duman', 'deniz.duman@example.com', 'Kadın', '1992-04-20'),
('Eren', 'Polat', 'eren.polat@example.com', 'Erkek', '1990-05-25'),
('Aylin', 'Kaya', 'aylin.kaya@example.com', 'Kadın', '1988-06-30'),
('Cem', 'Aktaş', 'cem.aktas@example.com', 'Erkek', '1994-07-25'),
('Büşra', 'Çetin', 'busra.cetin@example.com', 'Kadın', '1995-08-15');

-- _MemberSecurity_ tablosuna veri ekleme
INSERT INTO _MemberSecurity_ (MemberId, Password) VALUES
(1, 'password123'),
(2, 'password456'),
(3, 'password789'),
(4, 'password321'),
(5, 'password654'),
(6, 'password987'),
(7, 'password111'),
(8, 'password222'),
(9, 'password333'),
(10, 'password444'),
(11, 'password555'),
(12, 'password666'),
(13, 'password777'),
(14, 'password888'),
(15, 'password999'),
(16, 'password000'),
(17, 'password112'),
(18, 'password223'),
(19, 'password334'),
(20, 'password445');

INSERT INTO _QuestionType_
VAlUES 
('Çoktan seçmeli'),
('True/False'),
('Boşluk doldurma')

INSERT INTO _Library_ (MemberId, Name, Description, Category)
VALUES
(1, 'TYT Matematik Soruları', 'TYT (Temel Yeterlilik Testi) sınavı için matematik soruları.', 'Eğitim'),
(3, 'Veri Güvenliği Soruları', 'Bilgisayar güvenliği ve veri güvenliği alanında sorular.', 'Teknoloji'),
(5, 'İş Sağlığı ve Güvenliği Soruları', 'İş yerlerindeki sağlık ve güvenlikle ilgili sorular.', 'İş Sağlığı'),
(7, 'KPSS Türkçe Soruları', 'KPSS (Kamu Personeli Seçme Sınavı) sınavı için Türkçe soruları.', 'Eğitim'),
(9, 'Mühendislik Problemleri', 'Çeşitli mühendislik alanlarında karşılaşılan problemler.', 'Teknoloji');

INSERT INTO _Question_ (MemberId, LibraryId, QuestionType, Question, TrueAnswer, FalseAnswer2, FalseAnswer3, FalseAnswer4, FalseAnswer5, QuestionImg)
VALUES
-- TYT Matematik Soruları
(1, 1, 1, '2+2 kaç eder?', '4', '3', '5', '6', '7', NULL),
(1, 1, 1, '3x3 kaç eder?', '9', '6', '8', '12', '10', NULL),
(1, 1, 2, '5 çift sayıdır.', 'Yanlış', 'Doğru', NULL, NULL, NULL, NULL),
(1, 1, 3, '7x7 kaç eder? ___', '49', NULL, NULL, NULL, NULL, NULL),
(1, 1, 1, '12/4 kaç eder?', '3', '2', '4', '5', '6', NULL),

-- Veri Güvenliği Soruları
(3, 2, 1, 'Veri şifreleme nedir?', 'Veriyi gizlemek', 'Veriyi silmek', 'Veriyi kopyalamak', 'Veriyi taşımak', 'Veriyi değiştirmek', NULL),
(3, 2, 2, 'Güçlü bir şifre en az 8 karakterden oluşmalıdır.', 'Doğru', 'Yanlış', NULL, NULL, NULL, NULL),
(3, 2, 3, 'Veri güvenliğinde en önemli unsur ______\`dir.', 'Gizlilik', NULL, NULL, NULL, NULL, NULL),
(3, 2, 1, 'Kötü amaçlı yazılım nedir?', 'Zararlı yazılım', 'Antivirüs', 'Güvenlik duvarı', 'Yedekleme', 'Şifreleme', NULL),
(3, 2, 1, 'Veri ihlali nedir?', 'Yetkisiz erişim', 'Veri yedekleme', 'Veri analizi', 'Veri depolama', 'Veri silme', NULL),

-- İş Sağlığı ve Güvenliği Soruları
(5, 3, 1, 'İş kazası nedir?', 'İş sırasında meydana gelen kaza', 'Evde meydana gelen kaza', 'Trafik kazası', 'Doğal afet', 'Spor kazası', NULL),
(5, 3, 2, 'İş sağlığı ve güvenliği eğitimi zorunlu değildir.', 'Yanlış', 'Doğru', NULL, NULL, NULL, NULL),
(5, 3, 3, 'İş yerlerinde güvenlik ______ ile sağlanır.', 'Tedbirler', NULL, NULL, NULL, NULL, NULL),
(5, 3, 1, 'Yangın söndürme cihazı nasıl kullanılır?', 'Çek, nişan al, sık', 'Çek, vur, koş', 'Yak, kaç, bekle', 'Sık, bırak, sakla', 'Sık, yak, söndür', NULL),
(5, 3, 1, 'İş güvenliği şapkası ne amaçla kullanılır?', 'Baş yaralanmalarını önlemek', 'Ayak koruması', 'Eldiven olarak', 'Göz koruması', 'Kulak koruması', NULL),

-- KPSS Türkçe Soruları
(7, 4, 1, 'Aşağıdaki cümledeki anlatım bozukluğunu bulun.', 'Yanlış kelime kullanımı', 'Eksik özne', 'Yanlış zaman kullanımı', 'Eksik yüklem', 'Eksik nesne', NULL),
(7, 4, 2, 'Fiil kökünden türeyen sözcüklere fiilimsi denir.', 'Doğru', 'Yanlış', NULL, NULL, NULL, NULL),
(7, 4, 3, '______ zamiri cümlede nesne görevi yapar.', 'O', NULL, NULL, NULL, NULL, NULL),
(7, 4, 1, 'Eş anlamlısı en fazla olan kelime hangisidir?', 'Güzel', 'İyi', 'Kötü', 'Çirkin', 'Büyük', NULL),
(7, 4, 1, 'Şiirde ahenk hangi unsurlarla sağlanır?', 'Ölçü ve kafiye', 'Renk ve çizgi', 'Duygu ve düşünce', 'Şekil ve yapı', 'Ses ve anlam', NULL),

-- Mühendislik Problemleri
(9, 5, 1, 'Newtonun ikinci yasası nedir?', 'F=ma', 'E=mc^2', 'a^2+b^2=c^2', 'V=IR', 'PV=nRT', NULL),
(9, 5, 2, 'Stres ve gerilme aynı anlama gelir.', 'Yanlış', 'Doğru', NULL, NULL, NULL, NULL),
(9, 5, 3, 'Direnç ______ birimiyle ölçülür.', 'Ohm', NULL, NULL, NULL, NULL, NULL),
(9, 5, 1, 'Ohm Kanunu nedir?', 'V=IR', 'F=ma', 'E=mc^2', 'P=IV', 'Q=mcΔT', NULL),
(9, 5, 1, 'Isı transferi hangi yollarla gerçekleşir?', 'İletim, konveksiyon, radyasyon', 'Elektrik, manyetik, kimyasal', 'Difüzyon, ozmoz, filtrasyon', 'Kondüksiyon, difüzyon, radyasyon', 'İyonlaşma, rekombinasyon, buharlaşma', NULL);
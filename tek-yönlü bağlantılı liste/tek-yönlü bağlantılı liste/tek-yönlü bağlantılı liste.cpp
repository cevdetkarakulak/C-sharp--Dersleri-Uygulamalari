

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/*Listedeki düğümlerin veri yapısının tanımlanması*/
typedef struct topluluk {

	int bilgi;
	char mesaj[100];
	struct topluluk* arka;
}BLİSTE;

/*listenin ilk ve son düğüm adreslerinin tutan işaretçileri*/


BLİSTE* ilk = NULL, * son = NULL;

/*FONK BİLDİRİMLERİ*/

BLİSTE *ara(int);
BLİSTE *sil(int);
BLİSTE* okuKLAVYE();
void yazEkrana (BLİSTE *);
/*ana program*/
main(){
	BLİSTE *eklenecek, *ki;
	int bilgi, sonuc;
	char secim;
	while (1)
	{
		puts("/nEkleme/nListeleme/nAtama/nSilme/nÇıkış//nSeçiminiz");
		secim = getchar();
		switch (secim) {
		case 'E': eklenecek = okuKLAVYE();
			if (eklenecek != NULL)
				ekle(eklenecek);
			else
				puts("Ekleme için bellek dolu\n");
			break;
		case'L': sonuc = listele();
			if (sonuc == 1) puts("Boş Liste !");
			break;
		case'A': puts("Aranan:"); scanf("%d", &bilgi);
			ki = ara(bilgi);
			if (ki == NULL)
				puts("Aranan Bulunamadı");
			else
				yazEkrana(ki);
			break;
		case's':  puts("Silinecek:"); scanf("%d", &bilgi);
			ki = sil(bilgi);
			if (ki != NULL)
				puts("silindi...");
			else
				puts("Silinmek istenen yok!");
			break;
		case'ç':
		case'Ç':
		case'c':
		case'C':puts("Hoşçakal!");
			exit(0);
		default: puts("Yanlış Seçim!!!\n");
		}
    }
}

int ekle(BLİSTE *ki)
{
	if (ilk != NULL) {

		son->arka = ki;
		son = ki;
		son->arka = NULL;


	}

	return(0);


}



int listele() 
{
	BLİSTE *p;
	p = ilk;
	if (p == NULL) return -1;
	while (p)
	{
		yazEkrana(p);
		p = p->arka;
	}


	return 0;

}



BLİSTE* ara(int aranan)
{
	BLİSTE *p;

	p = ilk;
	while (p) {

		if (p->bilgi == aranan)
			return p;
		p = p->arka;
	}



	return NULL; 



}
	   


BLİSTE* sil(int silinecek)
{
	BLİSTE* p, * bironceki;
	p = ilk;
	bironceki = NULL;

	while (p) {

		if (silinecek == p->bilgi);
		break;

		bironceki = p;
		p = p->arka;
	}


	if (p != NULL)
	{


		if (bironceki == NULL) {



			if (ilk == son) {

				ilk = NULL;
				son = NULL;
			}
			else
				ilk = ilk->arka;
		}
		else {

			bironceki->arka = p->arka;
			if (bironceki->arka == NULL)

				son = bironceki;
		}
		free(p);
		return p;
	}
	else
		return NULL;

}



void yazEkrana(BLİSTE *yazilacak)

{
	printf("bilgi:%d, mesaj:&s\n", yazilacak->bilgi, yazilacak->mesaj);
}


BLİSTE *okuklavye()

{
	BLİSTE *okunan;
	okunan=malloc(sizeof(BLİSTE));
	if (okunan == NULL)

	return NULL;

	puts("BİLGİ GİRİNİZ:");
	scanf_s("%d", &(okunan->bilgi));
	puts("Mesaj Giriniz:");
	scanf_s("%s", okunan->mesaj);
	return okunan;}






















//#include <stdio.h>
//#include <stdlib.h>
//
///* Listedeki düğümlerin veri yapısının tanımlanması */
//typedef struct topluluk {
//    int bilgi;
//    char mesaj[100];
//    struct topluluk* arka;
//} BLİSTE;
//
///* Listenin ilk ve son düğüm adreslerinin tutan işaretçileri */
//BLİSTE* ilk = NULL, * son = NULL;
//
///* Fonksiyon bildirimleri */
//int ekle(BLİSTE*);
//int listele();
//BLİSTE* ara(int);
//BLİSTE* sil(int);
//void yazEkrana(BLİSTE*);
//BLİSTE* okuKLAVYE();
//
///* Ana program */
//
//
//
//
//
//
//int main() {
//    BLİSTE* eklenecek, * ki;
//    int bilgi, sonuc;
//    char secim;
//
//    while (1) {
//        printf("\nEkleme\nListeleme\nAtama\nSilme\nÇıkış\nSeçiminiz: ");
//        secim = getchar();
//
//        switch (secim) {
//        case 'E':
//            eklenecek = okuKLAVYE();
//            if (eklenecek != NULL)
//                ekle(eklenecek);
//            else
//                puts("Ekleme için bellek dolu\n");
//            break;
//        case 'L':
//            sonuc = listele();
//            if (sonuc == -1)
//                puts("Boş Liste !");
//            break;
//        case 'A':
//            puts("Aranan:");
//            scanf("%d", &bilgi);
//            ki = ara(bilgi);
//            if (ki == NULL)
//                puts("Aranan Bulunamadı");
//            else
//                yazEkrana(ki);
//            break;
//        case 'S':
//            puts("Silinecek:");
//            scanf("%d", &bilgi);
//            ki = sil(bilgi);
//            if (ki != NULL)
//                puts("Silindi...");
//            else
//                puts("Silinmek istenen yok!");
//            break;
//        case 'Ç':
//        case 'ç':
//            puts("Hoşçakal!");
//            exit(0);
//        default:
//            puts("Yanlış Seçim!!!\n");
//        }
//    }
//}
//
//int ekle(BLİSTE* ki) {
//    if (ilk != NULL) {
//        son->arka = ki;
//        son = ki;
//        son->arka = NULL;
//    }
//    else {
//        ilk = ki;
//        son = ki;
//        ki->arka = NULL;
//    }
//
//    return 0;
//}
//
//int listele() {
//    BLİSTE* p;
//    p = ilk;
//
//    if (p == NULL)
//        return -1;
//
//    while (p) {
//        yazEkrana(p);
//        p = p->arka;
//    }
//
//    return 0;
//}
//
//BLİSTE* ara(int aranan) {
//    BLİSTE* p;
//    p = ilk;
//
//    while (p) {
//        if (p->bilgi == aranan)
//            return p;
//        p = p->arka;
//    }
//
//    return NULL;
//}
//
//BLİSTE* sil(int silinecek) {
//    BLİSTE* p, * bironceki;
//    p = ilk;
//    bironceki = NULL;
//
//    while (p) {
//        if (silinecek == p->bilgi)
//            break;
//
//        bironceki = p;
//        p = p->arka;
//    }
//
//    if (p != NULL) {
//        if (bironceki == NULL) {
//            if (ilk == son) {
//                ilk = NULL;
//                son = NULL;
//            }
//            else
//                ilk = ilk->arka;
//        }
//        else {
//            bironceki->arka = p->arka;
//            if (bironceki->arka == NULL)
//                son = bironceki;
//        }
//        free(p);
//        return p;
//    }
//    else
//        return NULL;
//}
//
//void yazEkrana(BLİSTE* yazilacak) {
//    printf("Bilgi: %d, Mesaj: %s\n", yazilacak->bilgi, yazilacak->mesaj);
//}
//
//BLİSTE* okuKLAVYE() {
//    BLİSTE* okunan;
//    okunan = (BLİSTE*)malloc(sizeof(BLİSTE));
//
//    if (okunan == NULL)
//        return NULL;
//
//    printf("Bilgi Giriniz: ");
//    scanf("%d", &(okunan->bilgi));
//
//    printf("Mesaj Giriniz: ");
//    scanf("%s", okunan->mesaj);
//
//    return okunan;
//}
//
//

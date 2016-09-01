//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Uprava.h"
#include "Oprograme.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmUprava *frmUprava;
//---------------------------------------------------------------------------
__fastcall TfrmUprava::TfrmUprava(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmUprava::DefinovatNazovOkna(TObject *Sender)
{
        char * nazov_suboru = zostavitNazovSuboru(slovnik);

        DWORD citanie;

        int hPocet1, hPocet2;

        sSlovnik = CreateFile(nazov_suboru, GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

        if( sSlovnik == INVALID_HANDLE_VALUE )
        {
                if( MessageBox(Handle, nazov_suboru, "Nepodarilo sa otvoriù s˙bor slovnÌka", MB_OK | MB_ICONERROR) == IDOK )
                {
                        frmUprava->Close();
                        free(nazov_suboru);
                        return;
                }
        }

        //Nastavenie pracovnÈho jazyka a prostredia

        lblUpravaHladanieVysledokHladania->Caption = "";
        
        pnlUpravaHlavicka1->Caption = "Slovensko-" + jzPopisovac->Strings[1];
        pnlUpravaHlavicka2->Caption = jzPopisovac->Strings[2] + "-Slovensk˝";

        TListColumn * druha = lvwUpravaVychodziCudzi->Columns->Items[1];
        druha->Caption = "Preklad do " + jzPopisovac->Strings[3];

        edtUpravaPridat1Preklad->EditLabel->Caption = "Preklad(y) hesla do " + jzPopisovac->Strings[3];
        edtUpravaPridat2Vychodzi->EditLabel->Caption = "Heslo po " + jzPopisovac->Strings[4];
        //Nastaviù ukazovateæa s˙boru
        DWORD WINAPI puVysledok = SetFilePointer(sSlovnik, strlen(MAGICKE_CISLO), NULL, FILE_BEGIN);

        if( puVysledok == INVALID_SET_FILE_POINTER )
        {
                if( MessageBox(Handle, "Nepodarilo sa presun˙ù sa v s˙bore slovnÌka.", "Chyba ËÌtania", MB_OK | MB_ICONERROR) == IDOK )
                {
                        CloseHandle(sSlovnik);
                        free(nazov_suboru);
                        SendMessage(Handle, WM_CLOSE, 0, 0);
                        return;
                }
        }

        if( ReadFile(sSlovnik, &pocet_hesiel, sizeof(int), &citanie, NULL) == 0 )
        {
                if( MessageBox(Handle, "Nepodarilo sa naËÌtaù dÂûku slovnÌka.", "Chyba ËÌtania", MB_OK | MB_ICONERROR) == IDOK )
                {
                        CloseHandle(sSlovnik);
                        free(nazov_suboru);
                        SendMessage(Handle, WM_CLOSE, 0, 0);
                        return;
                }
        }

        if( slovnik.IsEmpty() )
        {
                frmUprava->Caption = "Slovoca - ⁄prava slovnÌka";
                return;
        }

        frmUprava->Caption = slovnik + " - ⁄prava slovnÌka (PoËet prekladov: " + pocet_hesiel + ")";

        puVysledok = SetFilePointer(sSlovnik, JAZYK_ISO_DLZKA, NULL, FILE_CURRENT);

        if( puVysledok == INVALID_SET_FILE_POINTER )
        {
                if( MessageBox(Handle, "Nepodarilo sa presun˙ù sa v s˙bore slovnÌka za hlaviËku.", "Chyba ËÌtania", MB_OK | MB_ICONERROR) == IDOK )
                {
                        CloseHandle(sSlovnik);
                        free(nazov_suboru);
                        SendMessage(Handle, WM_CLOSE, 0, 0);
                        return;
                }
        }

        if( pocet_hesiel > 0 )
        {
                lvwUpravaVychodziCudzi->Items->Clear();
                lvwUpravaCudziVychodzi->Items->Clear();

                if( ReadFile(sSlovnik, &hPocet1, sizeof(int), &citanie, NULL) == 0 )
                {
                        if( MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_OK | MB_ICONERROR) == IDOK )
                        {
                                CloseHandle(sSlovnik);
                                free(nazov_suboru);
                                SendMessage(Handle, WM_CLOSE, 0, 0);
                                return;
                        }
                }

                if( ReadFile(sSlovnik, &hPocet2, sizeof(int), &citanie, NULL) == 0 )
                {
                        if( MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_OK | MB_ICONERROR) == IDOK )
                        {
                                CloseHandle(sSlovnik);
                                free(nazov_suboru);
                                SendMessage(Handle, WM_CLOSE, 0, 0);
                                return;
                        }
                }

                for( int i = 0; i < hPocet1; i++ )
                {
                        int dlzka;

                        if( ReadFile(sSlovnik, &dlzka, sizeof(int), &citanie, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                return;
                        }

                        char * tPolozka = (char*) malloc(dlzka+1);

                        if( ReadFile(sSlovnik, tPolozka, dlzka, &citanie, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                return;
                        }

                        tPolozka[dlzka] = '\0';

                        TListItem * sPolozka = lvwUpravaVychodziCudzi->Items->Add();

                        sPolozka->Caption = AnsiString(tPolozka);

                        for( int j = 0; j < POCET_PODPOLOZIEK; j++ )
                        {
                                int pdlzka;

                                if( ReadFile(sSlovnik, &pdlzka, sizeof(int), &citanie, NULL) == 0 )
                                {
                                        MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                        return;
                                }

                                char *tPodPolozka = (char*) malloc(pdlzka+1);

                                if( ReadFile(sSlovnik, tPodPolozka, pdlzka, &citanie, NULL) == 0 )
                                {
                                        MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                        return;
                                }

                                tPodPolozka[pdlzka] = '\0';

                                sPolozka->SubItems->Add(tPodPolozka);

                                free(tPodPolozka);
                        }

                        free(tPolozka);
                }

                for( int i = 0; i < hPocet2; i++ )
                {
                        int dlzka;

                        if( ReadFile(sSlovnik, &dlzka, sizeof(int), &citanie, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                return;
                        }

                        char * tPolozka = (char*) malloc(dlzka+1);

                        if( ReadFile(sSlovnik, tPolozka, dlzka, &citanie, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                return;
                        }

                        tPolozka[dlzka] = '\0';

                        TListItem * sPolozka = lvwUpravaCudziVychodzi->Items->Add();

                        sPolozka->Caption = AnsiString(tPolozka);

                        for( int j = 0; j < POCET_PODPOLOZIEK; j++ )
                        {
                                int pdlzka;

                                if( ReadFile(sSlovnik, &pdlzka, sizeof(int), &citanie, NULL) == 0 )
                                {
                                        MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                        return;
                                }

                                char *tPodPolozka = (char*) malloc(pdlzka+1);

                                if( ReadFile(sSlovnik, tPodPolozka, pdlzka, &citanie, NULL) == 0 )
                                {
                                        MessageBox(Handle, "Nepodarilo sa naËÌtaù obsah slovnÌka.", "Chyba ËÌtania", MB_ICONERROR | MB_OK );
                                        return;
                                }

                                tPodPolozka[pdlzka] = '\0';

                                sPolozka->SubItems->Add(tPodPolozka);

                                free(tPodPolozka);
                        }

                        free(tPolozka);
                }
        }

        free(nazov_suboru);

        return;
}
//---------------------------------------------------------------------------
char * TfrmUprava::zostavitNazovSuboru(AnsiString meno)
{
        char * nazov_suboru = (char*) malloc(meno.Length()+strlen(DICT_LOC)+1);

        AnsiString nSubor = DICT_LOC + meno;

        strcpy(nazov_suboru, nSubor.c_str());

        nazov_suboru[nSubor.Length()] = '\0';

        return nazov_suboru;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::UkoncitUpravu(TObject *Sender)
{
        Close();
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::PridatPreklady1(TObject *Sender)
{
        if( edtUpravaPridat1Preklad->Text.IsEmpty() )
        {
                MessageBox(Handle, "Nezadali ste ûiaden preklad.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        lbxUpravaPridat1Preklady->Items->Add(edtUpravaPridat1Preklad->Text);
        edtUpravaPridat1Preklad->Text = "";
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::PridatPreklady2(TObject *Sender)
{
        if( edtUpravaPridat2Preklad->Text.IsEmpty() )
        {
                MessageBox(Handle, "Nezadali ste ûiaden preklad.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        lbxUpravaPridat2Preklady->Items->Add(edtUpravaPridat2Preklad->Text);
        edtUpravaPridat2Preklad->Text = "";
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::NacitajVyskakovaciuPonukuUprava(
      TObject *Sender)
{
        if( lbxUpravaPridat1Preklady->ItemIndex == -1 )
        {
                mniUpravaPridat1PrekladyPonukaZmazat->Enabled = false;
                mniUpravaPridat1PrekladyPonukaZmazat->Caption = "(nevybrali ste ûiadnu poloûku)";
        }
        else
        {
                mniUpravaPridat1PrekladyPonukaZmazat->Enabled = true;
                mniUpravaPridat1PrekladyPonukaZmazat->Caption = "&Zmazaù preklad";
        }
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::NacitajVyskakovaciuPonukuUprava2(
      TObject *Sender)
{
        if( lbxUpravaPridat2Preklady->ItemIndex == -1 )
        {
                mniUpravaPridat2PrekladyPonukaZmazat->Enabled = false;
                mniUpravaPridat2PrekladyPonukaZmazat->Caption = "(nevybrali ste ûiadnu poloûku)";
        }
        else
        {
                mniUpravaPridat2PrekladyPonukaZmazat->Enabled = true;
                mniUpravaPridat2PrekladyPonukaZmazat->Caption = "&Zmazaù preklad";
        }
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::PridatPrekladDoSlovnika1(TObject *Sender)
{
        if( edtUpravaPridat1Vychodzi->Text.IsEmpty() )
        {
                MessageBox(Handle, "Nezadali ste ûiadne heslo.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        if( lbxUpravaPridat1Preklady->Count < 1 )
        {
                MessageBox(Handle, "Nezadali ste ûiadny preklad.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        TListItem * heslo;

        for(int i = 0; i < lbxUpravaPridat1Preklady->Count; i++)
        {
                if( ZistitExistenciu(lvwUpravaVychodziCudzi, edtUpravaPridat1Vychodzi->Text, lbxUpravaPridat1Preklady->Items->Strings[i]) == false )
                {
                        heslo = lvwUpravaVychodziCudzi->Items->Add();
                        heslo->Caption = edtUpravaPridat1Vychodzi->Text;
                        heslo->SubItems->Add(lbxUpravaPridat1Preklady->Items->Strings[i]);
                        heslo->SubItems->Add(mmoUpravaPridat1Poznamky->Lines->Strings[i]);
                }
        }

        edtUpravaPridat1Vychodzi->Text = "";
        lbxUpravaPridat1Preklady->Clear();
        mmoUpravaPridat1Poznamky->Clear();

        pocet_hesiel++;

        frmUprava->Caption = slovnik + " - ⁄prava slovnÌka (PoËet prekladov: " + pocet_hesiel + ")";

        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::PridatPrekladDoSlovnika2(TObject *Sender)
{
        if( edtUpravaPridat2Vychodzi->Text.IsEmpty() )
        {
                MessageBox(Handle, "Nezadali ste ûiadne heslo.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        if( lbxUpravaPridat2Preklady->Count < 1 )
        {
                MessageBox(Handle, "Nezadali ste ûiadny preklad.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        TListItem * heslo;

        for(int i = 0; i < lbxUpravaPridat2Preklady->Count; i++)
        {
                if( ZistitExistenciu(lvwUpravaCudziVychodzi, edtUpravaPridat2Vychodzi->Text, lbxUpravaPridat2Preklady->Items->Strings[i]) == false )
                {
                        heslo = lvwUpravaCudziVychodzi->Items->Add();
                        heslo->Caption = edtUpravaPridat2Vychodzi->Text;
                        heslo->SubItems->Add(lbxUpravaPridat2Preklady->Items->Strings[i]);
                        heslo->SubItems->Add(mmoUpravaPridat2Poznamky->Lines->Strings[i]);
                }
        }

        edtUpravaPridat2Vychodzi->Text = "";
        lbxUpravaPridat2Preklady->Clear();
        mmoUpravaPridat2Poznamky->Clear();

        pocet_hesiel++;

        frmUprava->Caption = slovnik + " - ⁄prava slovnÌka (PoËet prekladov: " + pocet_hesiel + ")";

        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ZmazatPreklad1(TObject *Sender)
{
        if( mniUpravaPridat1PrekladyPonukaZmazat->Enabled == true )
        {
                lbxUpravaPridat1Preklady->DeleteSelected();
                return;
        }

        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ZmazatPreklad2(TObject *Sender)
{
        if( mniUpravaPridat2PrekladyPonukaZmazat->Enabled == true )
        {
                lbxUpravaPridat2Preklady->DeleteSelected();
                return;
        }

        return;
}
//---------------------------------------------------------------------------

bool TfrmUprava::ZistitExistenciu(TListView * zdrojUdajov, AnsiString heslo, AnsiString preklad)
{
        int pocet_hesiel = zdrojUdajov->Items->Count;

        if( pocet_hesiel < 1 )
        {
                return false;
        }

        for( int i = 0; i < pocet_hesiel; i++)
        {
                TListItem * h = zdrojUdajov->Items->operator [](i);

                if( h->Caption == heslo )
                {
                        for( int j = 0; j < h->SubItems->Count; j++ )
                        {
                                if( h->SubItems->Strings[j] == preklad )
                                {
                                        return true;
                                }
                        }
                }
        }

        return false;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ZmazatUdajovyRiadok1(TObject *Sender)
{
        lvwUpravaVychodziCudzi->DeleteSelected();
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::NacitajVyskakovaciuPonukuZdrojUdajovA(
      TObject *Sender)
{
        if( lvwUpravaVychodziCudzi->Selected == NULL )
        {
                mniUpravaZdrojUdajov1PonukaVybratVsetko->Enabled = false;
                mniUpravaZdrojUdajov1PonukaOdstranitVyber->Enabled = false;
        }
        else
        {
                mniUpravaZdrojUdajov1PonukaVybratVsetko->Enabled = true;
                mniUpravaZdrojUdajov1PonukaOdstranitVyber->Enabled = true;
        }
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::VybratVsetkyUdaje1(TObject *Sender)
{
        lvwUpravaVychodziCudzi->SelectAll();
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::NacitajVyskakovaciuPonukuZdrojUdajovB(
      TObject *Sender)
{
        if( lvwUpravaCudziVychodzi->Selected == NULL )
        {
                mniUpravaZdrojUdajov2PonukaVybratVsetko->Enabled = false;
                mniUpravaZdrojUdajov2PonukaOdstranitVyber->Enabled = false;
        }
        else
        {
                mniUpravaZdrojUdajov2PonukaVybratVsetko->Enabled = true;
                mniUpravaZdrojUdajov2PonukaOdstranitVyber->Enabled = true;
        }
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::VybratVsetkyUdaje2(TObject *Sender)
{
        lvwUpravaCudziVychodzi->SelectAll();
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ZmazatUdajovyRiadok2(TObject *Sender)
{
        lvwUpravaCudziVychodzi->DeleteSelected();        
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::UlozitPracu(TObject *Sender)
{
        UlozitVsetko();
        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::VyhladavatVyraz(TObject *Sender)
{
        //PredvolenÈ prÌpady

        //V slovnÌku nie je ûiadne heslo
        if( pocet_hesiel < 1 )
        {
                MessageBox(Handle, "Zadan˝ v˝raz nebol n·jden˝.", "V˝sledok vyhæad·vania", MB_OK | MB_ICONINFORMATION);
                return;
        }

        //Zadan˝ v˝raz je pr·zdny
        if( edtUpravaHladatHladanyVyraz->Text.IsEmpty() )
        {
                MessageBox(Handle, "Nezadali ste ûiaden v˝raz na vyhæad·vanie!", "Chyba vyhæad·vania", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        //Nie je vybrat˝ ûiaden z cieæov˝ch stÂpcov
        if( ( chbUpravaHladatVyberStlpcaHesla->Checked == false ) && ( chbUpravaHladatVyberStlpcaPreklady->Checked == false ) )
        {
                MessageBox(Handle, "Nezvolili ste, Ëi sa maj˙ prehæad·vaù preklady alebo hesl·!", "Chyba vyhæad·vania", MB_OK | MB_ICONEXCLAMATION);
                return;
        }

        bool Slovnik1 = rdbUpravaHladatVyberSlovnikaVychodziCudzi->Checked;
        bool Slovnik2 = rdbUpravaHladatVyberSlovnikaCudziVychodzi->Checked;

        bool hesla = chbUpravaHladatVyberStlpcaHesla->Checked;
        bool preklady = chbUpravaHladatVyberStlpcaPreklady->Checked;

        if( Slovnik1 )
        {
                for( int i = 0; i < lvwUpravaVychodziCudzi->Items->Count; i++ )
                {
                        TListItem * polozka = lvwUpravaVychodziCudzi->Items->operator [](i);

                        if( hesla )
                        {
                                if( CompareText(polozka->Caption, edtUpravaHladatHladanyVyraz->Text) == 0 )
                                {
                                        lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa naöiel medzi heslami.";
                                        lblUpravaHladanieVysledokHladania->Font->Color = clGreen;
                                        lvwUpravaVychodziCudzi->ItemIndex = i;
                                        edtUpravaHladatHladanyVyraz->Text = "";
                                        tmrUpravaHladatCasovac->Interval = 5000;
                                        return;
                                }

                                if( preklady )
                                {
                                        if( CompareText(polozka->SubItems->operator [](0), edtUpravaHladatHladanyVyraz->Text) == 0 )
                                        {
                                                lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa naöiel medzi prekladmi.";
                                                lblUpravaHladanieVysledokHladania->Font->Color = clGreen;
                                                lvwUpravaVychodziCudzi->ItemIndex = i;
                                                edtUpravaHladatHladanyVyraz->Text = "";
                                                tmrUpravaHladatCasovac->Interval = 5000;
                                                return;
                                        }
                                }
                        }

                        if( preklady )
                        {
                                if( CompareText(polozka->SubItems->operator [](0), edtUpravaHladatHladanyVyraz->Text) == 0 )
                                {
                                        lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa naöiel medzi prekladmi.";
                                        lblUpravaHladanieVysledokHladania->Font->Color = clGreen;
                                        lvwUpravaVychodziCudzi->ItemIndex = i;
                                        edtUpravaHladatHladanyVyraz->Text = "";
                                        tmrUpravaHladatCasovac->Interval = 5000;
                                        return;
                                }
                        }
                }

                lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa nenaöiel.";
                lblUpravaHladanieVysledokHladania->Font->Color = clRed;
                edtUpravaHladatHladanyVyraz->Text = "";
                tmrUpravaHladatCasovac->Interval = 5000;
                return;
        }

        if( Slovnik2 )
        {
                for( int i = 0; i < lvwUpravaCudziVychodzi->Items->Count; i++ )
                {
                        TListItem * polozka = lvwUpravaCudziVychodzi->Items->operator [](i);

                        if( hesla )
                        {
                                if( CompareText(polozka->Caption, edtUpravaHladatHladanyVyraz->Text) == 0 )
                                {
                                        lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa naöiel medzi heslami.";
                                        lblUpravaHladanieVysledokHladania->Font->Color = clGreen;
                                        lvwUpravaCudziVychodzi->ItemIndex = i;
                                        edtUpravaHladatHladanyVyraz->Text = "";
                                        tmrUpravaHladatCasovac->Interval = 5000;
                                        return;
                                }

                                if( preklady )
                                {
                                        if( CompareText(polozka->SubItems->operator [](0), edtUpravaHladatHladanyVyraz->Text) == 0 )
                                        {
                                                lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa naöiel medzi prekladmi.";
                                                lblUpravaHladanieVysledokHladania->Font->Color = clGreen;
                                                lvwUpravaCudziVychodzi->ItemIndex = i;
                                                edtUpravaHladatHladanyVyraz->Text = "";
                                                tmrUpravaHladatCasovac->Interval = 5000;
                                                return;
                                        }
                                }
                        }

                        if( preklady )
                        {
                                if( CompareText(polozka->SubItems->operator [](0), edtUpravaHladatHladanyVyraz->Text) == 0 )
                                {
                                        lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa naöiel medzi prekladmi.";
                                        lblUpravaHladanieVysledokHladania->Font->Color = clGreen;
                                        lvwUpravaCudziVychodzi->ItemIndex = i;
                                        edtUpravaHladatHladanyVyraz->Text = "";
                                        tmrUpravaHladatCasovac->Interval = 5000;
                                        return;
                                }
                        }
                }

                lblUpravaHladanieVysledokHladania->Caption = "V˝raz sa nenaöiel.";
                lblUpravaHladanieVysledokHladania->Font->Color = clRed;
                edtUpravaHladatHladanyVyraz->Text = "";
                tmrUpravaHladatCasovac->Interval = 5000;
                return;
        }

        edtUpravaHladatHladanyVyraz->Text = "";

        return;
}
//---------------------------------------------------------------------------


void __fastcall TfrmUprava::VycistitVysledokVyhladavania(TObject *Sender)
{
        lblUpravaHladanieVysledokHladania->Caption = "";        
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::UpravitZaznam(TObject *Sender, TListItem *Item,
      bool Selected)
{
        int polozka = lvwUpravaVychodziCudzi->ItemIndex;

        if( polozka < 0 )
        {
                return;
        }

        edtUpravaUpravaZaznamuHeslo->Enabled = true;
        edtUpravaUpravaZaznamuPreklad->Enabled = true;
        edtUpravaUpravaZaznamuPoznamka->Enabled = true;
        btnUpravaUpravaZaznamuPotvrdit->Enabled = true;

        TListItem * zaznam = lvwUpravaVychodziCudzi->Items->operator [](polozka);

        vyber_slovnika = 1;

        edtUpravaUpravaZaznamuHeslo->Text = zaznam->Caption;
        edtUpravaUpravaZaznamuPreklad->Text = zaznam->SubItems->Strings[0];
        edtUpravaUpravaZaznamuPoznamka->Text = zaznam->SubItems->Strings[1];
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::PotvrditUpravuZaznamu(TObject *Sender)
{
        TListView * slovnik;

        switch(vyber_slovnika)
        {
                case 1 :
                        slovnik = lvwUpravaVychodziCudzi;
                        break;
                case 2 :
                        slovnik = lvwUpravaCudziVychodzi;
                        break;
                default:
                        break;
        }

        int polozka = slovnik->ItemIndex;

        if( polozka < 0 )
        {
                return;
        }

        if( btnUpravaUpravaZaznamuPotvrdit->Enabled == false )
        {
                return;
        }

        TListItem * zaznam = slovnik->Items->operator [](polozka);

        zaznam->Caption = edtUpravaUpravaZaznamuHeslo->Text;
        zaznam->SubItems->Strings[0] = edtUpravaUpravaZaznamuPreklad->Text;
        zaznam->SubItems->Strings[1] = edtUpravaUpravaZaznamuPoznamka->Text;

        edtUpravaUpravaZaznamuHeslo->Text = "";
        edtUpravaUpravaZaznamuPreklad->Text = "";
        edtUpravaUpravaZaznamuPoznamka->Text = "";

        edtUpravaUpravaZaznamuHeslo->Enabled = false;
        edtUpravaUpravaZaznamuPreklad->Enabled = false;
        edtUpravaUpravaZaznamuPoznamka->Enabled = false;
        btnUpravaUpravaZaznamuPotvrdit->Enabled = false;

        vyber_slovnika = 0;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::UpravitZaznamCudzi(TObject *Sender,
      TListItem *Item, bool Selected)
{
        int polozka = lvwUpravaCudziVychodzi->ItemIndex;

        if( polozka < 0 )
        {
                return;
        }

        edtUpravaUpravaZaznamuHeslo->Enabled = true;
        edtUpravaUpravaZaznamuPreklad->Enabled = true;
        edtUpravaUpravaZaznamuPoznamka->Enabled = true;
        btnUpravaUpravaZaznamuPotvrdit->Enabled = true;

        TListItem * zaznam = lvwUpravaCudziVychodzi->Items->operator [](polozka);

        vyber_slovnika = 2;

        edtUpravaUpravaZaznamuHeslo->Text = zaznam->Caption;
        edtUpravaUpravaZaznamuPreklad->Text = zaznam->SubItems->Strings[0];
        edtUpravaUpravaZaznamuPoznamka->Text = zaznam->SubItems->Strings[1];
}
//---------------------------------------------------------------------------

void TfrmUprava::UlozitVsetko()
{
        TListItem * sPolozka;
        TStrings * sPodPolozky;
        DWORD zapis;
        int hPocet1 = lvwUpravaVychodziCudzi->Items->Count;
        int hPocet2 = lvwUpravaCudziVychodzi->Items->Count;

        DWORD WINAPI puVysledok = SetFilePointer(sSlovnik, strlen(MAGICKE_CISLO), NULL, FILE_BEGIN);

        if( puVysledok == INVALID_SET_FILE_POINTER )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        if( WriteFile(sSlovnik, &pocet_hesiel, sizeof(int), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        puVysledok = SetFilePointer(sSlovnik, JAZYK_ISO_DLZKA, NULL, FILE_CURRENT);

        if( puVysledok == INVALID_SET_FILE_POINTER )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        if( WriteFile(sSlovnik, &hPocet1, sizeof(int), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        if( WriteFile(sSlovnik, &hPocet2, sizeof(int), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        for( int i = 0; i < hPocet1; i++ )
        {
                sPolozka = lvwUpravaVychodziCudzi->Items->operator [](i);

                int dlzka = strlen(sPolozka->Caption.c_str());

                if( WriteFile(sSlovnik, &dlzka, sizeof(int), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                if( WriteFile(sSlovnik, sPolozka->Caption.c_str(), dlzka, &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                for( int j = 0; j < POCET_PODPOLOZIEK; j++ )
                {
                        sPodPolozky = sPolozka->SubItems;

                        int pdlzka = sPodPolozky->operator [](j).Length();

                        if( WriteFile(sSlovnik, &pdlzka, sizeof(int), &zapis, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                                return;
                        }

                        if( WriteFile(sSlovnik, sPodPolozky->operator [](j).c_str(), pdlzka, &zapis, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                                return;
                        }
                }
        }

        for( int i = 0; i < hPocet2; i++ )
        {
                sPolozka = lvwUpravaCudziVychodzi->Items->operator [](i);

                int dlzka = strlen(sPolozka->Caption.c_str());

                if( WriteFile(sSlovnik, &dlzka, sizeof(int), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                if( WriteFile(sSlovnik, sPolozka->Caption.c_str(), dlzka, &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                for( int j = 0; j < POCET_PODPOLOZIEK; j++ )
                {
                        sPodPolozky = sPolozka->SubItems;

                        int pdlzka = sPodPolozky->operator [](j).Length();

                        if( WriteFile(sSlovnik, &pdlzka, sizeof(int), &zapis, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                                return;
                        }

                        if( WriteFile(sSlovnik, sPodPolozky->operator [](j).c_str(), pdlzka, &zapis, NULL) == 0 )
                        {
                                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                                return;
                        }
                }
        }

        if( SetEndOfFile(sSlovnik) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù uloûen˙ pr·cu do s˙boru", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        return;
}
//---------------------------------------------------------------------------

void TfrmUprava::Zatvorit()
{
        switch( MessageBox(Handle, "Chcete uloûiù vykonanÈ zmeny pred zatvorenÌm s˙boru?", "Zatvoriù slovnÌk", MB_YESNO | MB_ICONQUESTION ) )
        {
                case ID_YES:
                        UlozitVsetko();
                        CloseHandle(sSlovnik);
                        frmUprava->Close();
                        break;
                case ID_NO:
                        CloseHandle(sSlovnik);
                        frmUprava->Close();
                        break;
        }

        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ZatvoritOkno(TObject *Sender,
      TCloseAction &Action)
{
        Zatvorit();
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ExportSlovnika(TObject *Sender, bool &CanClose)
{
        HANDLE eSubor = CreateFile(svdUpravaUlozenie->FileName.c_str(), GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
        DWORD zapis;

        if( eSubor == INVALID_HANDLE_VALUE )
        {
                MessageBox(Handle, "Nepodarilo sa vytvoriù cieæov˝ s˙bor!", "Chyba z·pisu", MB_OK | MB_ICONERROR);
                return;
        }

        if( WriteFile(eSubor, HTML_HLAVICKA, strlen(HTML_HLAVICKA), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù hlaviËku cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        AnsiString nadpis1 = "<H1>" + pnlUpravaHlavicka1->Caption + "</H1><BR>";

        if( WriteFile(eSubor, nadpis1.c_str(), nadpis1.Length(), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        if( WriteFile(eSubor, HTML_NADPIS_TAB, strlen(HTML_NADPIS_TAB), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        AnsiString tab_riadok_zac = "<TR>";
        AnsiString tab_riadok_koniec = "</TR>";

        for( int i = 0; i < lvwUpravaVychodziCudzi->Items->Count; i++ )
        {
                TListItem * sPolozka = lvwUpravaVychodziCudzi->Items->operator [](i);

                if( WriteFile(eSubor, tab_riadok_zac.c_str(), tab_riadok_zac.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                AnsiString riadok1 = "<TD STYLE='text-align=center;'>" + sPolozka->Caption + "</TD>";

                if( WriteFile(eSubor, riadok1.c_str(), riadok1.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                AnsiString riadok2 = "<TD STYLE='text-align=center;'>" + sPolozka->SubItems->Strings[0] + "</TD>";

                if( WriteFile(eSubor, riadok2.c_str(), riadok2.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                AnsiString riadok3 = "<TD STYLE='text-align=center;'>" + sPolozka->SubItems->Strings[1] + "</TD>";

                if( WriteFile(eSubor, riadok3.c_str(), riadok3.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                if( WriteFile(eSubor, tab_riadok_koniec.c_str(), tab_riadok_koniec.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }
        }

        if( WriteFile(eSubor, HTML_PATA_TAB, strlen(HTML_PATA_TAB), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        AnsiString nadpis2 = "<H1>" + pnlUpravaHlavicka2->Caption + "</H1><BR>";

        if( WriteFile(eSubor, nadpis2.c_str(), nadpis2.Length(), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        if( WriteFile(eSubor, HTML_NADPIS_TAB, strlen(HTML_NADPIS_TAB), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        for( int i = 0; i < lvwUpravaCudziVychodzi->Items->Count; i++ )
        {
                TListItem * sPolozka = lvwUpravaCudziVychodzi->Items->operator [](i);

                if( WriteFile(eSubor, tab_riadok_zac.c_str(), tab_riadok_zac.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                AnsiString riadok1 = "<TD STYLE='text-align=center;'>" + sPolozka->Caption + "</TD>";

                if( WriteFile(eSubor, riadok1.c_str(), riadok1.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                AnsiString riadok2 = "<TD STYLE='text-align=center;'>" + sPolozka->SubItems->Strings[0] + "</TD>";

                if( WriteFile(eSubor, riadok2.c_str(), riadok2.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                AnsiString riadok3 = "<TD STYLE='text-align=center;'>" + sPolozka->SubItems->Strings[1] + "</TD>";

                if( WriteFile(eSubor, riadok3.c_str(), riadok3.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }

                if( WriteFile(eSubor, tab_riadok_koniec.c_str(), tab_riadok_koniec.Length(), &zapis, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                        return;
                }
        }

        if( WriteFile(eSubor, HTML_PATA_TAB, strlen(HTML_PATA_TAB), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        if( WriteFile(eSubor, HTML_PATA, strlen(HTML_PATA), &zapis, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa zapÌsaù do cieæovÈho s˙boru!", "Chyba z·pisu", MB_ICONERROR | MB_OK );
                return;
        }

        CloseHandle(eSubor);
        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::SpustitExport(TObject *Sender)
{
        svdUpravaUlozenie->Execute();        
}
//---------------------------------------------------------------------------

void __fastcall TfrmUprava::ZobrazitInfo(TObject *Sender)
{
        frmOprograme->ShowModal();        
}
//---------------------------------------------------------------------------


//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Spustac.h"
#include "Novy.h"
#include "Uprava.h"
#include "Oprograme.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmSpustac *frmSpustac;
//---------------------------------------------------------------------------
__fastcall TfrmSpustac::TfrmSpustac(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmSpustac::UkoncitProgram(TObject *Sender)
{
        Close();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmSpustac::UrciNovySlovnik(TObject *Sender)
{
        frmNovy->ShowModal();
}
//---------------------------------------------------------------------------
void __fastcall TfrmSpustac::NajstExistujuceSlovniky(TObject *Sender)
{
        NajdiSlovniky();
        return;
}
//---------------------------------------------------------------------------
void __fastcall TfrmSpustac::NacitajSlovnik(TObject *Sender)
{
        HANDLE sSlovnik;
        DWORD citanie;

        char * nazov_suboru = (char*) malloc(lbxSpustacSlovniky->Items->Strings[lbxSpustacSlovniky->ItemIndex].Length()+strlen(DICT_LOC)+1);

        AnsiString nSubor = DICT_LOC + lbxSpustacSlovniky->Items->Strings[lbxSpustacSlovniky->ItemIndex];

        strcpy(nazov_suboru, nSubor.c_str());

        nazov_suboru[nSubor.Length()] = '\0';

        sSlovnik = CreateFile(nazov_suboru, GENERIC_READ, 0, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);

        if( sSlovnik == INVALID_HANDLE_VALUE )
        {
                MessageBox(Handle, nazov_suboru, "Nepodarilo sa otvori súbor slovníka", MB_OK | MB_ICONERROR);
                free(nazov_suboru);
                szPopis(1);
                return;
        }

        //Overi magické èíslo
        char * magicke = (char*) malloc(sizeof(MAGICKE_CISLO)+1);
        if( ReadFile(sSlovnik, magicke, strlen(MAGICKE_CISLO), &citanie, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa èíta súbor slovníka", "Chyba pri otváraní", MB_OK | MB_ICONERROR);
                free(magicke);
                free(nazov_suboru);
                CloseHandle(sSlovnik);
                szPopis(1);
                return;
        }
        magicke[strlen(MAGICKE_CISLO)] = '\0';
        if( strcmp(magicke, MAGICKE_CISLO) != 0 )
        {
                MessageBox(Handle, "Neplatný súbor", "Chyba pri otváraní", MB_OK | MB_ICONERROR);
                free(magicke);
                free(nazov_suboru);
                CloseHandle(sSlovnik);
                szPopis(1);
                return;
        }
        free(magicke);

        int pocet_hesiel = 0;

        if( ReadFile(sSlovnik, &pocet_hesiel, sizeof(int), &citanie, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa naèíta dåžku slovníka", "Chyba pri otváraní", MB_OK | MB_ICONERROR);
                free(nazov_suboru);
                CloseHandle(sSlovnik);
                szPopis(1);
                return;
        }

        if( ReadFile(sSlovnik, &jazyk, JAZYK_ISO_DLZKA, &citanie, NULL) == 0 )
        {
                MessageBox(Handle, "Nepodarilo sa naèíta pracovný jazyk slovníka", "Chyba pri otváraní", MB_OK | MB_ICONERROR);
                free(nazov_suboru);
                CloseHandle(sSlovnik);
                szPopis(1);
                return;
        }

        jazyk[JAZYK_ISO_DLZKA] = '\0';

        jzPopisovac = NastavitJazykovyPopisovac(jazyk);

        lblSpustacNicNevybrate->Visible = false;

        lblSpustacSlovnikNazov->Caption = lbxSpustacSlovniky->Items->Strings[lbxSpustacSlovniky->ItemIndex];
        lblSpustacSlovnikJazyk->Caption = jzPopisovac->Strings[0];
        lblSpustacSlovnikPocetHesiel->Caption = AnsiString(pocet_hesiel) + " hesiel";

        DWORD velkost_suboru = GetFileSize(sSlovnik, NULL);
        AnsiString vSubor;

        if( velkost_suboru < 1024 )
                vSubor = AnsiString(velkost_suboru) + " B";
        else
                vSubor = AnsiString(velkost_suboru/1024) + " kB";

        lblSpustacSlovnikVelkostSuboru->Caption = vSubor;

        CloseHandle(sSlovnik);

        HANDLE pSlovnik;
        WIN32_FIND_DATA priznaky;
        pSlovnik = FindFirstFile(nazov_suboru, &priznaky);

        FileTimeToLocalFileTime(&priznaky.ftCreationTime, &priznaky.ftCreationTime);
        FileTimeToLocalFileTime(&priznaky.ftLastWriteTime, &priznaky.ftLastWriteTime);

        SYSTEMTIME sc_vytvorenie, sc_p_upravy;

        FileTimeToSystemTime(&priznaky.ftCreationTime, &sc_vytvorenie);
        FileTimeToSystemTime(&priznaky.ftLastWriteTime, &sc_p_upravy);

        char cas_vytvorenia[255], cas_posl_upravy[255];

        GetDateFormat(LOCALE_USER_DEFAULT, DATE_LONGDATE, &sc_vytvorenie, NULL, cas_vytvorenia, 255);
        GetDateFormat(LOCALE_USER_DEFAULT, DATE_LONGDATE, &sc_p_upravy, NULL, cas_posl_upravy, 255);

        lblSpustacSlovnikDatumVytvorenia->Caption = AnsiString(cas_vytvorenia);
        lblSpustacSlovnikDatumPoslednejUpravy->Caption = AnsiString(cas_posl_upravy);

        FindClose(pSlovnik);

        szPopis(2);

        return;
}
//---------------------------------------------------------------------------
void TfrmSpustac::szPopis(unsigned int prepinac)
{
        switch(prepinac)
        {
                case 1:
                {
                        lblSpustacSlovnikNazov->Visible = false;
                        lblSpustacSlovnikDatumVytvorenia->Visible = false;
                        lblSpustacSlovnikDatumPoslednejUpravy->Visible = false;
                        lblSpustacSlovnikJazyk->Visible = false;
                        lblSpustacSlovnikPocetHesiel->Visible = false;
                        lblSpustacSlovnikVelkostSuboru->Visible = false;
                        btnSpustacSlovnikOtvorit->Visible = false;
                        lblSpustacNicNevybrate->Visible = true;
                        break;
                }
                case 2:
                {
                        lblSpustacSlovnikNazov->Visible = true;
                        lblSpustacSlovnikDatumVytvorenia->Visible = true;
                        lblSpustacSlovnikDatumPoslednejUpravy->Visible = true;
                        lblSpustacSlovnikJazyk->Visible = true;
                        lblSpustacSlovnikPocetHesiel->Visible = true;
                        lblSpustacSlovnikVelkostSuboru->Visible = true;
                        btnSpustacSlovnikOtvorit->Visible = true;
                        lblSpustacNicNevybrate->Visible = false;
                        break;
                }
                default:
                        break;
        }

        return;
}
//---------------------------------------------------------------------------

void __fastcall TfrmSpustac::NacitajVyskakovaciuPonuku(TObject *Sender)
{
        if( lbxSpustacSlovniky->ItemIndex == -1 )
        {
                mniSpustacPravyKlikZmazat->Enabled = false;
                mniSpustacPravyKlikZmazat->Caption = "(nevyznaèili ste žiaden súbor)";
                return;
        }
        else
        {
                mniSpustacPravyKlikZmazat->Enabled = true;
                mniSpustacPravyKlikZmazat->Caption = "&Zmaza súbor";
                return;
        }
}
//---------------------------------------------------------------------------

void __fastcall TfrmSpustac::ZmazatSubor(TObject *Sender)
{
        if( ( MessageBox(Handle, "Naozaj chcete natrvalo odstráni tento súbor slovníka z pevného disku?", "Potvrdenie odstránenia", MB_YESNO | MB_ICONQUESTION ) ) == IDYES )
        {
                char * nazov_suboru = (char*) malloc(lbxSpustacSlovniky->Items->Strings[lbxSpustacSlovniky->ItemIndex].Length()+strlen(DICT_LOC)+1);

                AnsiString nSubor = DICT_LOC + lbxSpustacSlovniky->Items->Strings[lbxSpustacSlovniky->ItemIndex];

                strcpy(nazov_suboru, nSubor.c_str());

                nazov_suboru[nSubor.Length()] = '\0';

                BOOL WINAPI vysledok;

                if( ( vysledok = DeleteFile(nazov_suboru) ) == ERROR_FILE_NOT_FOUND )
                {
                        MessageBox(Handle, "Zvolený súbor sa nepodarilo nájs.", "Chyba pri odstraòovaní súboru", MB_OK | MB_ICONERROR );
                        free(nazov_suboru);
                        return;
                }
                else if ( vysledok == ERROR_ACCESS_DENIED )
                {
                        MessageBox(Handle, "Zvolený súbor sa nepodarilo odstráni pretože ho používa iná osoba alebo program. Ukonèite všetky programy, ktoré by mohli súbor používa a skúste to znova.", "Chyba pri odstraòovaní súboru", MB_OK | MB_ICONERROR );
                        free(nazov_suboru);
                        return;
                }

                HANDLE slovSubor;
                WIN32_FIND_DATA NajdenySubor;

                lbxSpustacSlovniky->Clear();

                slovSubor = FindFirstFile(DCT_SUBOR_MASKA, &NajdenySubor);

                if( slovSubor != INVALID_HANDLE_VALUE )
                {
                        do
                        {
                                if( NajdenySubor.dwFileAttributes != FILE_ATTRIBUTE_DIRECTORY )
                                        lbxSpustacSlovniky->Items->Add(NajdenySubor.cFileName);
                        }
                        while( FindNextFile(slovSubor, &NajdenySubor) );
                }
                FindClose(slovSubor);

                return;
        }

        return;
}
//---------------------------------------------------------------------------
void __fastcall TfrmSpustac::SpustUpravuSlovnika(TObject *Sender)
{
        frmUprava->slovnik = lbxSpustacSlovniky->Items->Strings[lbxSpustacSlovniky->ItemIndex];
        frmUprava->jzPopisovac = jzPopisovac;
        frmUprava->ShowModal();
}
//---------------------------------------------------------------------------
TStringList * TfrmSpustac::NastavitJazykovyPopisovac(char jazyk[])
{
        TStringList * popisovace = new TStringList;

        AnsiString nazov_suboru = DATA_LOC + AnsiString(jazyk) + LD_PRIPONA;

        popisovace->LoadFromFile(nazov_suboru);

        return popisovace;
}
//---------------------------------------------------------------------------

void __fastcall TfrmSpustac::ZobrazitInfo(TObject *Sender)
{
        frmOprograme->ShowModal();        
}
//---------------------------------------------------------------------------

void TfrmSpustac::NajdiSlovniky()
{
        //Definova vyskakovaciu ponuku pre preiskumníka súborov
        lbxSpustacSlovniky->PopupMenu = pmuSpustacPravyKlik;

        HANDLE slovSubor;
        WIN32_FIND_DATA NajdenySubor;

        lbxSpustacSlovniky->Clear();

        slovSubor = FindFirstFile(DCT_SUBOR_MASKA, &NajdenySubor);

        if( slovSubor != INVALID_HANDLE_VALUE )
        {
                do
                {
                        if( NajdenySubor.dwFileAttributes != FILE_ATTRIBUTE_DIRECTORY )
                                lbxSpustacSlovniky->Items->Add(NajdenySubor.cFileName);
                }
                while( FindNextFile(slovSubor, &NajdenySubor) );
        }
        FindClose(slovSubor);

        return;
}

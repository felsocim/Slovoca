//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Novy.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfrmNovy *frmNovy;
//---------------------------------------------------------------------------
__fastcall TfrmNovy::TfrmNovy(TComponent* Owner)
        : TForm(Owner)
{
        jISO = new TStringList;
        jISO->LoadFromFile(JAZYKY);
        cmbNovyJazyk->Items->LoadFromFile(JAZYKY_CELY_NAZOV);
}
//---------------------------------------------------------------------------
void __fastcall TfrmNovy::ZrusitTvorbuNoveho(TObject *Sender)
{
        edtNovyMenoSuboru->Text = "";
        cmbNovyJazyk->Text = "Výber...";
        frmNovy->Close();
}
//---------------------------------------------------------------------------
void __fastcall TfrmNovy::VytvoritNovySuborSlovnika(TObject *Sender)
{
        //Zisti, èi používate¾ zadal všetky potrebné údaje
        if( ( edtNovyMenoSuboru->Text.IsEmpty() ) || ( cmbNovyJazyk->Text.AnsiCompare("Výber...") == 0 ) )
        {
                MessageBox(Handle, "Nezadali ste všetky potrebné údaje.", "Upozornenie", MB_OK | MB_ICONEXCLAMATION);
        }

        //Vytvori nový súbor slovníka
        HANDLE Novy_subor;
        DWORD zapisovanie;
        char * nazov_suboru = (char*) malloc(edtNovyMenoSuboru->Text.Length()+strlen(DICT_LOC)+strlen(SUBOR_SLOVNIKA_PRIPONA)+1);
        AnsiString cely_nazov = DICT_LOC + edtNovyMenoSuboru->Text + SUBOR_SLOVNIKA_PRIPONA;
        strcpy(nazov_suboru, cely_nazov.c_str());

        Novy_subor = CreateFile(nazov_suboru, GENERIC_WRITE, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

        if( Novy_subor == INVALID_HANDLE_VALUE )
        {
                MessageBox(Handle, "Nepodarilo sa vytvori nový slovník!", "Chyba", MB_OK | MB_ICONERROR);
                edtNovyMenoSuboru->Text = "";
                cmbNovyJazyk->Text = "Výber...";
                free(nazov_suboru);
                CloseHandle(Novy_subor);
        }
        else
        {
                free(nazov_suboru);

                char * magicke = (char*) malloc(sizeof(MAGICKE_CISLO)+1);
                strcpy(magicke, MAGICKE_CISLO);
                if( WriteFile(Novy_subor, magicke, strlen(MAGICKE_CISLO), &zapisovanie, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapísa informácie o novom slovníku do súboru!", "Chyba zápisu", MB_OK | MB_ICONERROR);
                        free(magicke);
                }
                free(magicke);
                int pocet_hesiel = 0;
                if( WriteFile(Novy_subor, &pocet_hesiel, sizeof(int), &zapisovanie, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapísa informácie o novom slovníku do súboru!", "Chyba zápisu", MB_OK | MB_ICONERROR);
                }
                char * jazyk = (char*) malloc(JAZYK_ISO_DLZKA+1);
                strcpy(jazyk, jISO->Strings[cmbNovyJazyk->ItemIndex].c_str());
                if( WriteFile(Novy_subor, jazyk, JAZYK_ISO_DLZKA, &zapisovanie, NULL) == 0 )
                {
                        MessageBox(Handle, "Nepodarilo sa zapísa informácie o novom slovníku do súboru!", "Chyba zápisu", MB_OK | MB_ICONERROR);
                        free(jazyk);
                }
                free(jazyk);

                edtNovyMenoSuboru->Text = "";
                cmbNovyJazyk->Text = "Výber...";
                CloseHandle(Novy_subor);
                frmNovy->Close();
        }
}
//---------------------------------------------------------------------------


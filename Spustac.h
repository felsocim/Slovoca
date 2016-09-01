//---------------------------------------------------------------------------

#ifndef SpustacH
#define SpustacH
#define DCT_SUBOR_MASKA "dict\\*.*"
#define DICT_LOC "dict\\"
#define MAGICKE_CISLO "$#SlovocaSlovnik$"
#define JAZYK_ISO_DLZKA 5
#define LD_PRIPONA ".langdesc"
#define DATA_LOC "data\\"
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <Menus.hpp>
#include <Buttons.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TfrmSpustac : public TForm
{
__published:	// IDE-managed Components
        TStatusBar *stbSpustacTipy;
        TMainMenu *mnuSpustacPonuka;
        TMenuItem *mniSpustacSubor;
        TMenuItem *mniSpustacPomoc;
        TMenuItem *mniSpustacSuborVytvorit;
        TMenuItem *N1;
        TMenuItem *mniSpustacSuborUkoncit;
        TMenuItem *mniSpustacPomocOprograme;
        TListBox *lbxSpustacSlovniky;
        TBevel *Bevel1;
        TLabel *lblSpustacNicNevybrate;
        TLabel *lblSpustacSlovnikNazov;
        TLabel *lblSpustacSlovnikDatumVytvorenia;
        TLabel *lblSpustacSlovnikDatumPoslednejUpravy;
        TLabel *lblSpustacSlovnikJazyk;
        TLabel *lblSpustacSlovnikPocetHesiel;
        TLabel *lblSpustacSlovnikVelkostSuboru;
        TBitBtn *btnSpustacSlovnikOtvorit;
        TPopupMenu *pmuSpustacPravyKlik;
        TMenuItem *mniSpustacPravyKlikZmazat;
        TBitBtn *btnSpustacObnovitZoznamSlovnikov;
        void __fastcall UkoncitProgram(TObject *Sender);
        void __fastcall UrciNovySlovnik(TObject *Sender);
        void __fastcall NajstExistujuceSlovniky(TObject *Sender);
        void __fastcall NacitajSlovnik(TObject *Sender);
        void __fastcall NacitajVyskakovaciuPonuku(TObject *Sender);
        void __fastcall ZmazatSubor(TObject *Sender);
        void __fastcall SpustUpravuSlovnika(TObject *Sender);
        void __fastcall ZobrazitInfo(TObject *Sender);
private:	// User declarations
public:
        char jazyk[JAZYK_ISO_DLZKA+1];
        TStringList * jzPopisovac;		// User declarations
        __fastcall TfrmSpustac(TComponent* Owner);
        void szPopis(unsigned int prepinac);
        TStringList * NastavitJazykovyPopisovac(char jazyk[]);
        void NajdiSlovniky();
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmSpustac *frmSpustac;
//---------------------------------------------------------------------------
#endif

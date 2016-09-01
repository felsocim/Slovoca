//---------------------------------------------------------------------------

#ifndef UpravaH
#define UpravaH

#define DICT_LOC "dict\\"
#define MAGICKE_CISLO "$#SlovocaSlovnik$"
#define JAZYK_ISO_DLZKA 5
#define LD_PRIPONA ".langdesc"
#define DATA_LOC "data\\"
#define POCET_PODPOLOZIEK 2
#define HTML_HLAVICKA "<HTML><HEAD><TITLE>Môj slovník</TITLE></HEAD><BODY>"
#define HTML_NADPIS_TAB "<TABLE WIDTH='70%' STYLE='padding=10px;' BORDER='1'><TR><TH>Heslo</TH><TH>Preklad</TH><TH>Poznámka</TH></TR>"
#define HTML_PATA_TAB "</TABLE>"
#define HTML_PATA "<P STYLE='padding=10px;'>Vytvorené programom Slovoca.<BR>Copyright (C) 1996 - 2016. Marek Felšöci. Všetky práva vyhradené!</P></BODY></HTML>"
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
#include <Menus.hpp>
#include <Buttons.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TfrmUprava : public TForm
{
__published:	// IDE-managed Components
        TMainMenu *mnuUprava;
        TMenuItem *mniUpravaSlovnik;
        TMenuItem *mniUpravaPomoc;
        TMenuItem *mniUpravaSlovnikUlozit;
        TMenuItem *mniUpravaSlovnikExport;
        TMenuItem *N1;
        TMenuItem *mniUpravaSlovnikZavriet;
        TMenuItem *mniUpravaPomocOprograme;
        TGroupBox *gpbUpravaPridatNoveHeslo1;
        TListView *lvwUpravaVychodziCudzi;
        TPanel *pnlUpravaHlavicka1;
        TPanel *pnlUpravaHlavicka2;
        TListView *lvwUpravaCudziVychodzi;
        TLabeledEdit *edtUpravaPridat1Vychodzi;
        TLabeledEdit *edtUpravaPridat1Preklad;
        TBitBtn *btnUpravaPridat1PridatPreklad;
        TListBox *lbxUpravaPridat1Preklady;
        TBitBtn *btnUpravaPridat1Potvrdenie;
        TGroupBox *gpbUpravaPridatNoveHeslo2;
        TLabeledEdit *edtUpravaPridat2Vychodzi;
        TLabeledEdit *edtUpravaPridat2Preklad;
        TBitBtn *btnUpravaPridat2PridatPreklad;
        TListBox *lbxUpravaPridat2Preklady;
        TBitBtn *btnUpravaPridat2Potvrdenie;
        TPopupMenu *pmuUpravaPridat1PrekladyPonuka;
        TMenuItem *mniUpravaPridat1PrekladyPonukaZmazat;
        TPopupMenu *pmuUpravaPridat2PrekladyPonuka;
        TMenuItem *mniUpravaPridat2PrekladyPonukaZmazat;
        TMemo *mmoUpravaPridat1Poznamky;
        TMemo *mmoUpravaPridat2Poznamky;
        TPopupMenu *pmuUpravaZdrojUdajov1Ponuka;
        TMenuItem *mniUpravaZdrojUdajov1PonukaOdstranitVyber;
        TMenuItem *mniUpravaZdrojUdajov1PonukaVybratVsetko;
        TPopupMenu *pmuUpravaZdrojUdajov2Ponuka;
        TMenuItem *mniUpravaZdrojUdajov2PonukaVybratVsetko;
        TMenuItem *mniUpravaZdrojUdajov2PonukaOdstranitVyber;
        TGroupBox *gpbUpravaHladat;
        TLabeledEdit *edtUpravaHladatHladanyVyraz;
        TBitBtn *btnUpravaHladatChod;
        TRadioGroup *rgpUpravaHladatVyberSlovnika;
        TRadioButton *rdbUpravaHladatVyberSlovnikaVychodziCudzi;
        TRadioButton *rdbUpravaHladatVyberSlovnikaCudziVychodzi;
        TGroupBox *grpUpravaHladatVyberStlpca;
        TCheckBox *chbUpravaHladatVyberStlpcaHesla;
        TCheckBox *chbUpravaHladatVyberStlpcaPreklady;
        TLabel *lblUpravaHladanieVysledokHladania;
        TTimer *tmrUpravaHladatCasovac;
        TGroupBox *gpbUpravaUpravaZaznamu;
        TLabeledEdit *edtUpravaUpravaZaznamuHeslo;
        TLabeledEdit *edtUpravaUpravaZaznamuPreklad;
        TBitBtn *btnUpravaUpravaZaznamuPotvrdit;
        TLabeledEdit *edtUpravaUpravaZaznamuPoznamka;
        TStaticText *sttUpravaUpravaZaznamuPopis;
        TStaticText *sttUpravaUpravaZaznamuPopis2;
        TSaveDialog *svdUpravaUlozenie;
        void __fastcall DefinovatNazovOkna(TObject *Sender);
        void __fastcall UkoncitUpravu(TObject *Sender);
        void __fastcall PridatPreklady1(TObject *Sender);
        void __fastcall PridatPreklady2(TObject *Sender);
        void __fastcall NacitajVyskakovaciuPonukuUprava(TObject *Sender);
        void __fastcall NacitajVyskakovaciuPonukuUprava2(TObject *Sender);
        void __fastcall PridatPrekladDoSlovnika1(TObject *Sender);
        void __fastcall PridatPrekladDoSlovnika2(TObject *Sender);
        void __fastcall ZmazatPreklad1(TObject *Sender);
        void __fastcall ZmazatPreklad2(TObject *Sender);
        void __fastcall ZmazatUdajovyRiadok1(TObject *Sender);
        void __fastcall NacitajVyskakovaciuPonukuZdrojUdajovA(
          TObject *Sender);
        void __fastcall VybratVsetkyUdaje1(TObject *Sender);
        void __fastcall NacitajVyskakovaciuPonukuZdrojUdajovB(
          TObject *Sender);
        void __fastcall VybratVsetkyUdaje2(TObject *Sender);
        void __fastcall ZmazatUdajovyRiadok2(TObject *Sender);
        void __fastcall UlozitPracu(TObject *Sender);
        void __fastcall VyhladavatVyraz(TObject *Sender);
        void __fastcall VycistitVysledokVyhladavania(TObject *Sender);
        void __fastcall UpravitZaznam(TObject *Sender, TListItem *Item,
          bool Selected);
        void __fastcall PotvrditUpravuZaznamu(TObject *Sender);
        void __fastcall UpravitZaznamCudzi(TObject *Sender,
          TListItem *Item, bool Selected);
        void __fastcall ZatvoritOkno(TObject *Sender,
          TCloseAction &Action);
        void __fastcall ExportSlovnika(TObject *Sender, bool &CanClose);
        void __fastcall SpustitExport(TObject *Sender);
        void __fastcall ZobrazitInfo(TObject *Sender);
private:	// User declarations
public:
        AnsiString slovnik;
        TStringList * jzPopisovac;
        HANDLE sSlovnik;
        int pocet_hesiel;
        unsigned int vyber_slovnika;		// User declarations
        __fastcall TfrmUprava(TComponent* Owner);
        char * zostavitNazovSuboru(AnsiString meno);
        bool ZistitExistenciu(TListView * zdrojUdajov, AnsiString heslo, AnsiString preklad);
        void UlozitVsetko();
        void Zatvorit();
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmUprava *frmUprava;
//---------------------------------------------------------------------------
#endif

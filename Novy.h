//---------------------------------------------------------------------------

#ifndef NovyH
#define NovyH
#define JAZYKY "data\\Jazyky.langsdesc"
#define JAZYKY_CELY_NAZOV "data\\JazykyCN.langsdesc"
#define DICT_LOC "dict\\"
#define SUBOR_SLOVNIKA_PRIPONA ".dct"
#define MAGICKE_CISLO "$#SlovocaSlovnik$"
#define JAZYK_ISO_DLZKA 5
#define LD_PRIPONA ".langdesc"
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TfrmNovy : public TForm
{
__published:	// IDE-managed Components
        TLabel *lblNovyJazyk;
        TComboBox *cmbNovyJazyk;
        TLabeledEdit *edtNovyMenoSuboru;
        TBitBtn *btnNovyZrusit;
        TBitBtn *btnNovyPokracovat;
        void __fastcall ZrusitTvorbuNoveho(TObject *Sender);
        void __fastcall VytvoritNovySuborSlovnika(TObject *Sender);
private:	// User declarations
public:
        TStringList * jISO;		// User declarations
        __fastcall TfrmNovy(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmNovy *frmNovy;
//---------------------------------------------------------------------------
#endif

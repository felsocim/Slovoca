//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("Spustac.cpp", frmSpustac);
USEFORM("Novy.cpp", frmNovy);
USEFORM("Uprava.cpp", frmUprava);
USEFORM("Oprograme.cpp", frmOprograme);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->Title = "Slovoca";
                 Application->CreateForm(__classid(TfrmSpustac), &frmSpustac);
                 Application->CreateForm(__classid(TfrmNovy), &frmNovy);
                 Application->CreateForm(__classid(TfrmUprava), &frmUprava);
                 Application->CreateForm(__classid(TfrmOprograme), &frmOprograme);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        catch (...)
        {
                 try
                 {
                         throw Exception("");
                 }
                 catch (Exception &exception)
                 {
                         Application->ShowException(&exception);
                 }
        }
        return 0;
}
//---------------------------------------------------------------------------

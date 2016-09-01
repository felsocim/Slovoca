object frmSpustac: TfrmSpustac
  Left = 560
  Top = 187
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'Slovoca - Moje slovn'#237'ky'
  ClientHeight = 194
  ClientWidth = 424
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Icon.Data = {
    0000010001001010100000000000280100001600000028000000100000002000
    00000100040000000000C0000000000000000000000000000000000000000000
    000000008000008000000080800080000000800080008080000080808000C0C0
    C0000000FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF001111
    1111111111111111111111111111111F11FFFF111111111FFF111FF111111111
    F1111FF111111111F1111FF111111111111FFF111111111111FFF11111111111
    1FFF1111111111111FF111F1111111111FF111F1111111111FF111FF11111111
    11FFFF1F11111111111111111111111111111111111111111111111111110000
    0000000000000000000000000000000000000000000000000000000000000000
    000000000000000000000000000000000000000000000000000000000000}
  Menu = mnuSpustacPonuka
  OldCreateOrder = False
  Position = poScreenCenter
  OnActivate = NajstExistujuceSlovniky
  OnCreate = NajstExistujuceSlovniky
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    Left = 216
    Top = 8
    Width = 200
    Height = 160
  end
  object lblSpustacNicNevybrate: TLabel
    Left = 232
    Top = 80
    Width = 164
    Height = 13
    Caption = 'Nevybrali ste '#382'iaden slovn'#237'k.'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object lblSpustacSlovnikNazov: TLabel
    Left = 232
    Top = 24
    Width = 99
    Height = 13
    Caption = 'N'#225'zov slovn'#237'ka'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = [fsBold]
    ParentFont = False
    Visible = False
  end
  object lblSpustacSlovnikDatumVytvorenia: TLabel
    Left = 232
    Top = 48
    Width = 76
    Height = 13
    Caption = 'DD.MM.RRRR'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    Visible = False
  end
  object lblSpustacSlovnikDatumPoslednejUpravy: TLabel
    Left = 232
    Top = 72
    Width = 76
    Height = 13
    Caption = 'DD.MM.RRRR'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    Visible = False
  end
  object lblSpustacSlovnikJazyk: TLabel
    Left = 232
    Top = 96
    Width = 32
    Height = 13
    Caption = 'Jazyk'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    Visible = False
  end
  object lblSpustacSlovnikPocetHesiel: TLabel
    Left = 232
    Top = 120
    Width = 43
    Height = 13
    Caption = '? hesiel'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    Visible = False
  end
  object lblSpustacSlovnikVelkostSuboru: TLabel
    Left = 232
    Top = 144
    Width = 25
    Height = 13
    Caption = '? kB'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    Visible = False
  end
  object stbSpustacTipy: TStatusBar
    Left = 0
    Top = 175
    Width = 424
    Height = 19
    Panels = <>
    SimplePanel = False
  end
  object lbxSpustacSlovniky: TListBox
    Left = 8
    Top = 8
    Width = 200
    Height = 129
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ItemHeight = 13
    ParentFont = False
    TabOrder = 1
    OnClick = NacitajSlovnik
  end
  object btnSpustacSlovnikOtvorit: TBitBtn
    Left = 334
    Top = 136
    Width = 75
    Height = 25
    Caption = '&Otvori'#357
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Visible = False
    OnClick = SpustUpravuSlovnika
    Glyph.Data = {
      76010000424D7601000000000000760000002800000020000000100000000100
      04000000000000010000120B0000120B00001000000000000000000000000000
      800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
      FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333000000
      000033333377777777773333330FFFFFFFF03FF3FF7FF33F3FF700300000FF0F
      00F077F777773F737737E00BFBFB0FFFFFF07773333F7F3333F7E0BFBF000FFF
      F0F077F3337773F3F737E0FBFBFBF0F00FF077F3333FF7F77F37E0BFBF00000B
      0FF077F3337777737337E0FBFBFBFBF0FFF077F33FFFFFF73337E0BF0000000F
      FFF077FF777777733FF7000BFB00B0FF00F07773FF77373377373330000B0FFF
      FFF03337777373333FF7333330B0FFFF00003333373733FF777733330B0FF00F
      0FF03333737F37737F373330B00FFFFF0F033337F77F33337F733309030FFFFF
      00333377737FFFFF773333303300000003333337337777777333}
    NumGlyphs = 2
  end
  object btnSpustacObnovitZoznamSlovnikov: TBitBtn
    Left = 72
    Top = 144
    Width = 139
    Height = 25
    Caption = 'Obnovi'#357' zoznam'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = NajstExistujuceSlovniky
    Glyph.Data = {
      76010000424D7601000000000000760000002800000020000000100000000100
      04000000000000010000120B0000120B00001000000000000000000000000000
      800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
      FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00300130000031
      00333773F77777FF7733331000909000133333377737F777FF33330098F0F890
      0333337733F733F77F33370980FFF08907333373373F373373F33099FF0FFFF9
      903337F3F373F33FF7F33090FFF0FF00903337F73337F37737F33099FFF0FFF9
      9033373F33F7F3F33733370980F0F0890733337FF737F7337F33330098F0F890
      03333F77FF3733377FFF000009999900000377777FFFFF77777F088700000008
      77037F3377777773337F088887707888870373F3337773F33373307880707088
      7033373FF737F73FF733337003303300733333777337FF777333333333000333
      3333333333777333333333333333333333333333333333333333}
    NumGlyphs = 2
  end
  object mnuSpustacPonuka: TMainMenu
    Left = 8
    Top = 144
    object mniSpustacSubor: TMenuItem
      Caption = 'S'#250'bor'
      object mniSpustacSuborVytvorit: TMenuItem
        Caption = 'Vy&tvori'#357' slovn'#237'k...'
        ShortCut = 16462
        OnClick = UrciNovySlovnik
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object mniSpustacSuborUkoncit: TMenuItem
        Caption = 'U&kon'#269'i'#357
        ShortCut = 32883
        OnClick = UkoncitProgram
      end
    end
    object mniSpustacPomoc: TMenuItem
      Caption = 'Pomoc'
      object mniSpustacPomocOprograme: TMenuItem
        Caption = 'O programe...'
        ShortCut = 112
        OnClick = ZobrazitInfo
      end
    end
  end
  object pmuSpustacPravyKlik: TPopupMenu
    OnPopup = NacitajVyskakovaciuPonuku
    Left = 40
    Top = 144
    object mniSpustacPravyKlikZmazat: TMenuItem
      Bitmap.Data = {
        E6000000424DE60000000000000076000000280000000E0000000E0000000100
        0400000000007000000000000000000000001000000000000000000000000000
        BF0000BF000000BFBF00BF000000BF00BF00BFBF0000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3300333333333333330033333333333333003333333333333300333333333333
        330033333333333333003300000000003300330FFFFFFFF03300330000000000
        3300333333333333330033333333333333003333333333333300333333333333
        33003333333333333300}
      Caption = '&Zmaza'#357' s'#250'bor'
      OnClick = ZmazatSubor
    end
  end
end

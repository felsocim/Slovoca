object frmOprograme: TfrmOprograme
  Left = 447
  Top = 102
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'O programe Slovoca'
  ClientHeight = 211
  ClientWidth = 298
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
  OldCreateOrder = True
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 8
    Top = 8
    Width = 281
    Height = 161
    BevelInner = bvRaised
    BevelOuter = bvLowered
    ParentColor = True
    TabOrder = 0
    object ProgramIcon: TImage
      Left = 8
      Top = 8
      Width = 33
      Height = 33
      Picture.Data = {
        055449636F6E0000010001002020100000000000E80200001600000028000000
        2000000040000000010004000000000080020000000000000000000000000000
        0000000000000000000080000080000000808000800000008000800080800000
        80808000C0C0C0000000FF0000FF000000FFFF00FF000000FF00FF00FFFF0000
        FFFFFF0011111111111111111111111111111111111111111111111111111111
        1111111111111111111111111111111111111111111111111111111111111111
        1111111111111111111111111111111111111111FFFFFFF1111111111FFFFFFF
        FFFFFF11FFFFFFFF111111FFFFFFFFFFF1F1F1F1FFFFFFFFF11111F1F1F1F111
        1F1F1F1F11FFFFFFFFF111F1F1F1F1111F1F1F1F1111FFFFFFFF111111111111
        1F1F1F1F111111FFFFFFFF1111111111F1F1F1F11111111FFFFFFFF11111111F
        FFFFFFF111111111FFFFFFFF111111FFFFFFFF111111111111F1F1F1F1111FFF
        FFFFF11111111111111F1F1F1F11FFFFFFFF1111111111111111F1F1FFFFFFFF
        FF1111111111111111111FFFFFFFFFF111111111111111111111FFFFFFFFF111
        11111111111111111FFFFFFFFFF1F1111111111111111111FFFFFFFFFFFFFF11
        111111111111111F1F1F1F1F1F1F1F1111111111111111FFFFFFFF1FFFFFFFF1
        11111111111111F1F1F1F111F1F1F1F111111111111111F1F1F1F111F1F1F1F1
        11111111111111F1F1F1F111F1F1F1F111111111111111FFFFFFFF1F1F1F1F11
        111111111111111F1F1F1FFFFFFFFF111111111111111111FFFFFFFFFFFFF111
        1111111111111111111111111111111111111111111111111111111111111111
        1111111111111111111111111111111111111111111111111111111111111111
        1111111100000000000000000000000000000000000000000000000000000000
        0000000000000000000000000000000000000000000000000000000000000000
        0000000000000000000000000000000000000000000000000000000000000000
        0000000000000000000000000000000000000000000000000000000000000000
        00000000}
      Stretch = True
      IsControl = True
    end
    object ProductName: TLabel
      Left = 48
      Top = 16
      Width = 83
      Height = 23
      Caption = 'Slovoca'
      Font.Charset = EASTEUROPE_CHARSET
      Font.Color = clWindowText
      Font.Height = -19
      Font.Name = 'Verdana'
      Font.Style = [fsBold]
      ParentFont = False
      IsControl = True
    end
    object Version: TLabel
      Left = 48
      Top = 48
      Width = 97
      Height = 18
      Caption = 'Vydanie 1.0'
      Font.Charset = EASTEUROPE_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Verdana'
      Font.Style = []
      ParentFont = False
      IsControl = True
    end
    object Copyright: TLabel
      Left = 48
      Top = 80
      Width = 160
      Height = 13
      Caption = 'Copyright (C) Marek Fel'#353#246'ci'
      Font.Charset = EASTEUROPE_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Verdana'
      Font.Style = []
      ParentFont = False
      IsControl = True
    end
    object Comments: TLabel
      Left = 8
      Top = 104
      Width = 265
      Height = 26
      Caption = 
        'Slovoca je program na spravovanie vlastn'#253'ch slovn'#237'kov cudz'#237'ch ja' +
        'zykov.'
      Font.Charset = EASTEUROPE_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Verdana'
      Font.Style = []
      ParentFont = False
      WordWrap = True
      IsControl = True
    end
    object Label1: TLabel
      Left = 8
      Top = 136
      Width = 220
      Height = 13
      Caption = 'Viac info na: www.marekonline.eu'
      Font.Charset = EASTEUROPE_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Verdana'
      Font.Style = [fsBold]
      ParentFont = False
    end
  end
  object OKButton: TButton
    Left = 111
    Top = 180
    Width = 75
    Height = 25
    Caption = 'OK'
    Default = True
    ModalResult = 1
    TabOrder = 1
  end
end

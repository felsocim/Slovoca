object frmUprava: TfrmUprava
  Left = 235
  Top = 107
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'Slovoca - '#218'prava slovn'#237'ka'
  ClientHeight = 577
  ClientWidth = 1009
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
  Menu = mnuUprava
  OldCreateOrder = False
  Position = poScreenCenter
  OnClose = ZatvoritOkno
  OnShow = DefinovatNazovOkna
  PixelsPerInch = 96
  TextHeight = 13
  object gpbUpravaPridatNoveHeslo1: TGroupBox
    Left = 8
    Top = 8
    Width = 345
    Height = 321
    Caption = 'Prida'#357' nov'#233' heslo'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    object edtUpravaPridat1Vychodzi: TLabeledEdit
      Left = 16
      Top = 40
      Width = 313
      Height = 21
      EditLabel.Width = 110
      EditLabel.Height = 13
      EditLabel.Caption = 'Heslo po slovensky'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 0
    end
    object edtUpravaPridat1Preklad: TLabeledEdit
      Left = 16
      Top = 88
      Width = 273
      Height = 21
      EditLabel.Width = 165
      EditLabel.Height = 13
      EditLabel.Caption = 'Preklad(y) hesla do <jazyk>'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 1
    end
    object btnUpravaPridat1PridatPreklad: TBitBtn
      Left = 296
      Top = 88
      Width = 35
      Height = 25
      TabOrder = 2
      OnClick = PridatPreklady1
      Glyph.Data = {
        E6000000424DE60000000000000076000000280000000E0000000E0000000100
        0400000000007000000000000000000000001000000000000000000000000000
        BF0000BF000000BFBF00BF000000BF00BF00BFBF0000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3300333333333333330033333333333333003333300033333300333330F03333
        3300333330F033333300330000F000033300330FFFFFFF033300330000F00003
        3300333330F033333300333330F0333333003333300033333300333333333333
        33003333333333333300}
    end
    object lbxUpravaPridat1Preklady: TListBox
      Left = 16
      Top = 120
      Width = 313
      Height = 97
      ItemHeight = 13
      MultiSelect = True
      PopupMenu = pmuUpravaPridat1PrekladyPonuka
      TabOrder = 3
    end
    object btnUpravaPridat1Potvrdenie: TBitBtn
      Left = 248
      Top = 288
      Width = 83
      Height = 25
      Caption = 'Potvrdi'#357
      TabOrder = 4
      OnClick = PridatPrekladDoSlovnika1
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00555555555555
        555555555555555555555555555555555555555555FF55555555555559055555
        55555555577FF5555555555599905555555555557777F5555555555599905555
        555555557777FF5555555559999905555555555777777F555555559999990555
        5555557777777FF5555557990599905555555777757777F55555790555599055
        55557775555777FF5555555555599905555555555557777F5555555555559905
        555555555555777FF5555555555559905555555555555777FF55555555555579
        05555555555555777FF5555555555557905555555555555777FF555555555555
        5990555555555555577755555555555555555555555555555555}
      NumGlyphs = 2
    end
    object mmoUpravaPridat1Poznamky: TMemo
      Left = 16
      Top = 224
      Width = 313
      Height = 57
      ScrollBars = ssVertical
      TabOrder = 5
    end
  end
  object lvwUpravaVychodziCudzi: TListView
    Left = 8
    Top = 368
    Width = 345
    Height = 201
    Columns = <
      item
        Caption = 'Heslo'
        Width = 81
      end
      item
        Caption = 'Preklad do nem'#269'iny'
        Width = 110
      end
      item
        Caption = 'Pozn'#225'mky k prekladu'
        Width = 150
      end>
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    GridLines = True
    HideSelection = False
    MultiSelect = True
    ParentFont = False
    PopupMenu = pmuUpravaZdrojUdajov1Ponuka
    SortType = stText
    TabOrder = 1
    ViewStyle = vsReport
    OnSelectItem = UpravitZaznam
  end
  object pnlUpravaHlavicka1: TPanel
    Left = 8
    Top = 336
    Width = 345
    Height = 25
    BevelInner = bvLowered
    BevelOuter = bvLowered
    Caption = 'Slovensko-<jazykov'#253'>'
    Color = clWhite
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 2
  end
  object pnlUpravaHlavicka2: TPanel
    Left = 360
    Top = 336
    Width = 345
    Height = 25
    BevelInner = bvLowered
    BevelOuter = bvLowered
    Caption = '<jazykovo>-Slovensk'#253
    Color = clWhite
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 3
  end
  object lvwUpravaCudziVychodzi: TListView
    Left = 360
    Top = 368
    Width = 345
    Height = 201
    Columns = <
      item
        Caption = 'Heslo'
        Width = 81
      end
      item
        Caption = 'Preklad do sloven'#269'iny'
        Width = 110
      end
      item
        Caption = 'Pozn'#225'mky k prekladu'
        Width = 150
      end>
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    GridLines = True
    HideSelection = False
    MultiSelect = True
    ParentFont = False
    PopupMenu = pmuUpravaZdrojUdajov2Ponuka
    SortType = stText
    TabOrder = 4
    ViewStyle = vsReport
    OnSelectItem = UpravitZaznamCudzi
  end
  object gpbUpravaPridatNoveHeslo2: TGroupBox
    Left = 360
    Top = 8
    Width = 345
    Height = 321
    Caption = 'Prida'#357' nov'#233' heslo'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    object edtUpravaPridat2Vychodzi: TLabeledEdit
      Left = 16
      Top = 40
      Width = 313
      Height = 21
      EditLabel.Width = 102
      EditLabel.Height = 13
      EditLabel.Caption = 'Heslo po <jazyk>'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 0
    end
    object edtUpravaPridat2Preklad: TLabeledEdit
      Left = 16
      Top = 88
      Width = 273
      Height = 21
      EditLabel.Width = 176
      EditLabel.Height = 13
      EditLabel.Caption = 'Preklad(y) hesla do sloven'#269'iny'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 1
    end
    object btnUpravaPridat2PridatPreklad: TBitBtn
      Left = 296
      Top = 88
      Width = 35
      Height = 25
      TabOrder = 2
      OnClick = PridatPreklady2
      Glyph.Data = {
        E6000000424DE60000000000000076000000280000000E0000000E0000000100
        0400000000007000000000000000000000001000000000000000000000000000
        BF0000BF000000BFBF00BF000000BF00BF00BFBF0000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3300333333333333330033333333333333003333300033333300333330F03333
        3300333330F033333300330000F000033300330FFFFFFF033300330000F00003
        3300333330F033333300333330F0333333003333300033333300333333333333
        33003333333333333300}
    end
    object lbxUpravaPridat2Preklady: TListBox
      Left = 16
      Top = 120
      Width = 313
      Height = 97
      ItemHeight = 13
      MultiSelect = True
      PopupMenu = pmuUpravaPridat2PrekladyPonuka
      TabOrder = 3
    end
    object btnUpravaPridat2Potvrdenie: TBitBtn
      Left = 248
      Top = 288
      Width = 83
      Height = 25
      Caption = 'Potvrdi'#357
      TabOrder = 4
      OnClick = PridatPrekladDoSlovnika2
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000120B0000120B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00555555555555
        555555555555555555555555555555555555555555FF55555555555559055555
        55555555577FF5555555555599905555555555557777F5555555555599905555
        555555557777FF5555555559999905555555555777777F555555559999990555
        5555557777777FF5555557990599905555555777757777F55555790555599055
        55557775555777FF5555555555599905555555555557777F5555555555559905
        555555555555777FF5555555555559905555555555555777FF55555555555579
        05555555555555777FF5555555555557905555555555555777FF555555555555
        5990555555555555577755555555555555555555555555555555}
      NumGlyphs = 2
    end
    object mmoUpravaPridat2Poznamky: TMemo
      Left = 16
      Top = 224
      Width = 313
      Height = 57
      ScrollBars = ssVertical
      TabOrder = 5
    end
  end
  object gpbUpravaHladat: TGroupBox
    Left = 712
    Top = 8
    Width = 289
    Height = 321
    Caption = 'Vyh'#318'ad'#225'vanie'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    object lblUpravaHladanieVysledokHladania: TLabel
      Left = 24
      Top = 288
      Width = 139
      Height = 13
      Caption = '<v'#253'sledok h'#318'adania>'
      Font.Charset = EASTEUROPE_CHARSET
      Font.Color = clWindowText
      Font.Height = -11
      Font.Name = 'Verdana'
      Font.Style = [fsBold]
      ParentFont = False
    end
    object edtUpravaHladatHladanyVyraz: TLabeledEdit
      Left = 16
      Top = 40
      Width = 257
      Height = 21
      EditLabel.Width = 82
      EditLabel.Height = 13
      EditLabel.Caption = 'H'#318'adan'#253' v'#253'raz'
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 0
    end
    object btnUpravaHladatChod: TBitBtn
      Left = 192
      Top = 248
      Width = 83
      Height = 25
      Caption = '&H'#318'ada'#357
      TabOrder = 1
      OnClick = VyhladavatVyraz
      Glyph.Data = {
        76010000424D7601000000000000760000002800000020000000100000000100
        04000000000000010000130B0000130B00001000000000000000000000000000
        800000800000008080008000000080008000808000007F7F7F00BFBFBF000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        333333333333333333FF33333333333330003FF3FFFFF3333777003000003333
        300077F777773F333777E00BFBFB033333337773333F7F33333FE0BFBF000333
        330077F3337773F33377E0FBFBFBF033330077F3333FF7FFF377E0BFBF000000
        333377F3337777773F3FE0FBFBFBFBFB039977F33FFFFFFF7377E0BF00000000
        339977FF777777773377000BFB03333333337773FF733333333F333000333333
        3300333777333333337733333333333333003333333333333377333333333333
        333333333333333333FF33333333333330003333333333333777333333333333
        3000333333333333377733333333333333333333333333333333}
      NumGlyphs = 2
    end
    object rgpUpravaHladatVyberSlovnika: TRadioGroup
      Left = 16
      Top = 72
      Width = 257
      Height = 81
      Caption = 'Cie'#318'ov'#253' slovn'#237'k'
      TabOrder = 2
    end
    object rdbUpravaHladatVyberSlovnikaVychodziCudzi: TRadioButton
      Left = 32
      Top = 96
      Width = 233
      Height = 17
      Caption = 'Slovensko-<jazykov'#253'>'
      Checked = True
      TabOrder = 3
      TabStop = True
    end
    object rdbUpravaHladatVyberSlovnikaCudziVychodzi: TRadioButton
      Left = 32
      Top = 120
      Width = 233
      Height = 17
      Caption = '<jazykovo>-Slovensk'#253
      TabOrder = 4
    end
    object grpUpravaHladatVyberStlpca: TGroupBox
      Left = 16
      Top = 160
      Width = 257
      Height = 81
      Caption = 'Cie'#318'ov'#253' st'#314'pec'
      TabOrder = 5
      object chbUpravaHladatVyberStlpcaHesla: TCheckBox
        Left = 16
        Top = 24
        Width = 201
        Height = 17
        Caption = 'H'#318'ada'#357' medzi heslami'
        Checked = True
        State = cbChecked
        TabOrder = 0
      end
      object chbUpravaHladatVyberStlpcaPreklady: TCheckBox
        Left = 16
        Top = 48
        Width = 201
        Height = 17
        Caption = 'H'#318'ada'#357' medzi prekladmi'
        Checked = True
        State = cbChecked
        TabOrder = 1
      end
    end
  end
  object gpbUpravaUpravaZaznamu: TGroupBox
    Left = 712
    Top = 336
    Width = 289
    Height = 233
    Caption = #218'prava polo'#382'ky'
    Font.Charset = EASTEUROPE_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 7
    object edtUpravaUpravaZaznamuHeslo: TLabeledEdit
      Left = 16
      Top = 72
      Width = 257
      Height = 21
      EditLabel.Width = 36
      EditLabel.Height = 13
      EditLabel.Caption = 'Heslo:'
      Enabled = False
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 0
    end
    object edtUpravaUpravaZaznamuPreklad: TLabeledEdit
      Left = 16
      Top = 120
      Width = 257
      Height = 21
      EditLabel.Width = 48
      EditLabel.Height = 13
      EditLabel.Caption = 'Preklad:'
      Enabled = False
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 1
    end
    object btnUpravaUpravaZaznamuPotvrdit: TBitBtn
      Left = 192
      Top = 200
      Width = 83
      Height = 25
      Caption = 'Upravi'#357
      Enabled = False
      TabOrder = 2
      OnClick = PotvrditUpravuZaznamu
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
    object edtUpravaUpravaZaznamuPoznamka: TLabeledEdit
      Left = 16
      Top = 168
      Width = 257
      Height = 21
      EditLabel.Width = 129
      EditLabel.Height = 13
      EditLabel.Caption = 'Pozn'#225'mka k prekladu:'
      Enabled = False
      LabelPosition = lpAbove
      LabelSpacing = 3
      TabOrder = 3
    end
    object sttUpravaUpravaZaznamuPopis: TStaticText
      Left = 16
      Top = 24
      Width = 232
      Height = 17
      Caption = 'Vyberte polo'#382'ku z jedn'#233'ho zo slovn'#237'kov'
      TabOrder = 4
    end
    object sttUpravaUpravaZaznamuPopis2: TStaticText
      Left = 16
      Top = 40
      Width = 172
      Height = 17
      Caption = 'a upravte po'#382'adovan'#233' '#250'daje.'
      TabOrder = 5
    end
  end
  object mnuUprava: TMainMenu
    Left = 8
    Top = 336
    object mniUpravaSlovnik: TMenuItem
      Caption = '&Slovn'#237'k'
      object mniUpravaSlovnikUlozit: TMenuItem
        Caption = '&Ulo'#382'i'#357
        ShortCut = 16467
        OnClick = UlozitPracu
      end
      object mniUpravaSlovnikExport: TMenuItem
        Caption = '&Exportova'#357' do HTML...'
        ShortCut = 16453
        OnClick = SpustitExport
      end
      object N1: TMenuItem
        Caption = '-'
      end
      object mniUpravaSlovnikZavriet: TMenuItem
        Caption = '&Zavrie'#357
        ShortCut = 32883
        OnClick = UkoncitUpravu
      end
    end
    object mniUpravaPomoc: TMenuItem
      Caption = '&Pomoc'
      object mniUpravaPomocOprograme: TMenuItem
        Caption = 'O programe...'
        ShortCut = 112
        OnClick = ZobrazitInfo
      end
    end
  end
  object pmuUpravaPridat1PrekladyPonuka: TPopupMenu
    OnPopup = NacitajVyskakovaciuPonukuUprava
    Left = 32
    Top = 192
    object mniUpravaPridat1PrekladyPonukaZmazat: TMenuItem
      Bitmap.Data = {
        E6000000424DE60000000000000076000000280000000E0000000E0000000100
        0400000000007000000000000000000000001000000000000000000000000000
        BF0000BF000000BFBF00BF000000BF00BF00BFBF0000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3300333333333333330033333333333333003333333333333300333333333333
        330033333333333333003300000000003300330FFFFFFFF03300330000000000
        3300333333333333330033333333333333003333333333333300333333333333
        33003333333333333300}
      Caption = '&Zmaza'#357' preklad'
      OnClick = ZmazatPreklad1
    end
  end
  object pmuUpravaPridat2PrekladyPonuka: TPopupMenu
    OnPopup = NacitajVyskakovaciuPonukuUprava2
    Left = 384
    Top = 192
    object mniUpravaPridat2PrekladyPonukaZmazat: TMenuItem
      Bitmap.Data = {
        E6000000424DE60000000000000076000000280000000E0000000E0000000100
        0400000000007000000000000000000000001000000000000000000000000000
        BF0000BF000000BFBF00BF000000BF00BF00BFBF0000C0C0C000808080000000
        FF0000FF000000FFFF00FF000000FF00FF00FFFF0000FFFFFF00333333333333
        3300333333333333330033333333333333003333333333333300333333333333
        330033333333333333003300000000003300330FFFFFFFF03300330000000000
        3300333333333333330033333333333333003333333333333300333333333333
        33003333333333333300}
      Caption = '&Zmaza'#357' preklad'
      OnClick = ZmazatPreklad2
    end
  end
  object pmuUpravaZdrojUdajov1Ponuka: TPopupMenu
    OnPopup = NacitajVyskakovaciuPonukuZdrojUdajovA
    Left = 16
    Top = 536
    object mniUpravaZdrojUdajov1PonukaVybratVsetko: TMenuItem
      Caption = '&Vybra'#357' v'#353'etko'
      ShortCut = 16449
      OnClick = VybratVsetkyUdaje1
    end
    object mniUpravaZdrojUdajov1PonukaOdstranitVyber: TMenuItem
      Caption = '&Odstr'#225'ni'#357' v'#253'ber'
      ShortCut = 46
      OnClick = ZmazatUdajovyRiadok1
    end
  end
  object pmuUpravaZdrojUdajov2Ponuka: TPopupMenu
    OnPopup = NacitajVyskakovaciuPonukuZdrojUdajovB
    Left = 368
    Top = 536
    object mniUpravaZdrojUdajov2PonukaVybratVsetko: TMenuItem
      Caption = '&Vybra'#357' v'#353'etko'
      ShortCut = 16449
      OnClick = VybratVsetkyUdaje2
    end
    object mniUpravaZdrojUdajov2PonukaOdstranitVyber: TMenuItem
      Caption = '&Odstr'#225'ni'#357' v'#253'ber'
      ShortCut = 46
      OnClick = ZmazatUdajovyRiadok2
    end
  end
  object tmrUpravaHladatCasovac: TTimer
    Interval = 5000
    OnTimer = VycistitVysledokVyhladavania
    Left = 728
    Top = 256
  end
  object svdUpravaUlozenie: TSaveDialog
    DefaultExt = '*.html'
    FileName = 'Bez_n'#225'zvu.html'
    Filter = 'S'#250'bor HTML (*.html)|*.html|V'#353'etky s'#250'bory (*.*)|*.*'
    InitialDir = '%USERPROFILE%'
    Title = 'Exportova'#357' slovn'#237'k do s'#250'boru HTML'
    OnCanClose = ExportSlovnika
    Left = 40
    Top = 336
  end
end

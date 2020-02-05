using System;
using System.Collections.Generic;
using System.Text;

namespace TbcBank.EcommerceClient
{
    public enum CurrencyCode
    {
        /// <summary>
        /// Afghani
        /// </summary>
        AFN = 971,
        /// <summary>
        /// Euro
        /// </summary>
        EUR = 978,
        /// <summary>
        /// Lek
        /// </summary>
        ALL = 008,
        /// <summary>
        /// Algerian Dinar
        /// </summary>
        DZD = 012,
        /// <summary>
        /// US Dollar
        /// </summary>
        USD = 840,
        /// <summary>
        /// Kwanza
        /// </summary>
        AOA = 973,
        /// <summary>
        /// East Caribbean Dollar
        /// </summary>
        XCD = 951,
        /// <summary>
        /// Argentine Peso
        /// </summary>
        ARS = 032,
        /// <summary>
        /// Armenian Dram
        /// </summary>
        AMD = 051,
        /// <summary>
        /// Aruban Florin
        /// </summary>
        AWG = 533,
        /// <summary>
        /// Australian Dollar
        /// </summary>
        AUD = 036,
        /// <summary>
        /// Azerbaijan Manat
        /// </summary>
        AZN = 944,
        /// <summary>
        /// Bahamian Dollar
        /// </summary>
        BSD = 044,
        /// <summary>
        /// Bahraini Dinar
        /// </summary>
        BHD = 048,
        /// <summary>
        /// Taka
        /// </summary>
        BDT = 050,
        /// <summary>
        /// Barbados Dollar
        /// </summary>
        BBD = 052,
        /// <summary>
        /// Belarusian Ruble
        /// </summary>
        BYN = 933,
        /// <summary>
        /// Belize Dollar
        /// </summary>
        BZD = 084,
        /// <summary>
        /// CFA Franc BCEAO
        /// </summary>
        XOF = 952,
        /// <summary>
        /// Bermudian Dollar
        /// </summary>
        BMD = 060,
        /// <summary>
        /// Indian Rupee
        /// </summary>
        INR = 356,
        /// <summary>
        /// Ngultrum
        /// </summary>
        BTN = 064,
        /// <summary>
        /// Boliviano
        /// </summary>
        BOB = 068,
        /// <summary>
        /// Mvdol
        /// </summary>
        BOV = 984,
        /// <summary>
        /// Convertible Mark
        /// </summary>
        BAM = 977,
        /// <summary>
        /// Pula
        /// </summary>
        BWP = 072,
        /// <summary>
        /// Norwegian Krone
        /// </summary>
        NOK = 578,
        /// <summary>
        /// Brazilian Real
        /// </summary>
        BRL = 986,
        /// <summary>
        /// Brunei Dollar
        /// </summary>
        BND = 096,
        /// <summary>
        /// Bulgarian Lev
        /// </summary>
        BGN = 975,
        /// <summary>
        /// Burundi Franc
        /// </summary>
        BIF = 108,
        /// <summary>
        /// Cabo Verde Escudo
        /// </summary>
        CVE = 132,
        /// <summary>
        /// Riel
        /// </summary>
        KHR = 116,
        /// <summary>
        /// CFA Franc BEAC
        /// </summary>
        XAF = 950,
        /// <summary>
        /// Canadian Dollar
        /// </summary>
        CAD = 124,
        /// <summary>
        /// Cayman Islands Dollar
        /// </summary>
        KYD = 136,
        /// <summary>
        /// Chilean Peso
        /// </summary>
        CLP = 152,
        /// <summary>
        /// Unidad de Fomento
        /// </summary>
        CLF = 990,
        /// <summary>
        /// Yuan Renminbi
        /// </summary>
        CNY = 156,
        /// <summary>
        /// Colombian Peso
        /// </summary>
        COP = 170,
        /// <summary>
        /// Unidad de Valor Real
        /// </summary>
        COU = 970,
        /// <summary>
        /// Comorian Franc 
        /// </summary>
        KMF = 174,
        /// <summary>
        /// Congolese Franc
        /// </summary>
        CDF = 976,
        /// <summary>
        /// New Zealand Dollar
        /// </summary>
        NZD = 554,
        /// <summary>
        /// Costa Rican Colon
        /// </summary>
        CRC = 188,
        /// <summary>
        /// Kuna
        /// </summary>
        HRK = 191,
        /// <summary>
        /// Cuban Peso
        /// </summary>
        CUP = 192,
        /// <summary>
        /// Peso Convertible
        /// </summary>
        CUC = 931,
        /// <summary>
        /// Netherlands Antillean Guilder
        /// </summary>
        ANG = 532,
        /// <summary>
        /// Czech Koruna
        /// </summary>
        CZK = 203,
        /// <summary>
        /// Danish Krone
        /// </summary>
        DKK = 208,
        /// <summary>
        /// Djibouti Franc
        /// </summary>
        DJF = 262,
        /// <summary>
        /// Dominican Peso
        /// </summary>
        DOP = 214,
        /// <summary>
        /// Egyptian Pound
        /// </summary>
        EGP = 818,
        /// <summary>
        /// El Salvador Colon
        /// </summary>
        SVC = 222,
        /// <summary>
        /// Nakfa
        /// </summary>
        ERN = 232,
        /// <summary>
        /// Ethiopian Birr
        /// </summary>
        ETB = 230,
        /// <summary>
        /// Falkland Islands Pound
        /// </summary>
        FKP = 238,
        /// <summary>
        /// Fiji Dollar
        /// </summary>
        FJD = 242,
        /// <summary>
        /// CFP Franc
        /// </summary>
        XPF = 953,
        /// <summary>
        /// Dalasi
        /// </summary>
        GMD = 270,
        /// <summary>
        /// Lari
        /// </summary>
        GEL = 981,
        /// <summary>
        /// Ghana Cedi
        /// </summary>
        GHS = 936,
        /// <summary>
        /// Gibraltar Pound
        /// </summary>
        GIP = 292,
        /// <summary>
        /// Quetzal
        /// </summary>
        GTQ = 320,
        /// <summary>
        /// Pound Sterling
        /// </summary>
        GBP = 826,
        /// <summary>
        /// Guinean Franc
        /// </summary>
        GNF = 324,
        /// <summary>
        /// Guyana Dollar
        /// </summary>
        GYD = 328,
        /// <summary>
        /// Gourde
        /// </summary>
        HTG = 332,
        /// <summary>
        /// Lempira
        /// </summary>
        HNL = 340,
        /// <summary>
        /// Hong Kong Dollar
        /// </summary>
        HKD = 344,
        /// <summary>
        /// Forint
        /// </summary>
        HUF = 348,
        /// <summary>
        /// Iceland Krona
        /// </summary>
        ISK = 352,
        /// <summary>
        /// Rupiah
        /// </summary>
        IDR = 360,
        /// <summary>
        /// SDR (Special Drawing Right)
        /// </summary>
        XDR = 960,
        /// <summary>
        /// Iranian Rial
        /// </summary>
        IRR = 364,
        /// <summary>
        /// Iraqi Dinar
        /// </summary>
        IQD = 368,
        /// <summary>
        /// New Israeli Sheqel
        /// </summary>
        ILS = 376,
        /// <summary>
        /// Jamaican Dollar
        /// </summary>
        JMD = 388,
        /// <summary>
        /// Yen
        /// </summary>
        JPY = 392,
        /// <summary>
        /// Jordanian Dinar
        /// </summary>
        JOD = 400,
        /// <summary>
        /// Tenge
        /// </summary>
        KZT = 398,
        /// <summary>
        /// Kenyan Shilling
        /// </summary>
        KES = 404,
        /// <summary>
        /// North Korean Won
        /// </summary>
        KPW = 408,
        /// <summary>
        /// Won
        /// </summary>
        KRW = 410,
        /// <summary>
        /// Kuwaiti Dinar
        /// </summary>
        KWD = 414,
        /// <summary>
        /// Som
        /// </summary>
        KGS = 417,
        /// <summary>
        /// Lao Kip
        /// </summary>
        LAK = 418,
        /// <summary>
        /// Lebanese Pound
        /// </summary>
        LBP = 422,
        /// <summary>
        /// Loti
        /// </summary>
        LSL = 426,
        /// <summary>
        /// Rand
        /// </summary>
        ZAR = 710,
        /// <summary>
        /// Liberian Dollar
        /// </summary>
        LRD = 430,
        /// <summary>
        /// Libyan Dinar
        /// </summary>
        LYD = 434,
        /// <summary>
        /// Swiss Franc
        /// </summary>
        CHF = 756,
        /// <summary>
        /// Pataca
        /// </summary>
        MOP = 446,
        /// <summary>
        /// Denar
        /// </summary>
        MKD = 807,
        /// <summary>
        /// Malagasy Ariary
        /// </summary>
        MGA = 969,
        /// <summary>
        /// Malawi Kwacha
        /// </summary>
        MWK = 454,
        /// <summary>
        /// Malaysian Ringgit
        /// </summary>
        MYR = 458,
        /// <summary>
        /// Rufiyaa
        /// </summary>
        MVR = 462,
        /// <summary>
        /// Ouguiya
        /// </summary>
        MRU = 929,
        /// <summary>
        /// Mauritius Rupee
        /// </summary>
        MUR = 480,
        /// <summary>
        /// ADB Unit of Account
        /// </summary>
        XUA = 965,
        /// <summary>
        /// Mexican Peso
        /// </summary>
        MXN = 484,
        /// <summary>
        /// Mexican Unidad de Inversion (UDI)
        /// </summary>
        MXV = 979,
        /// <summary>
        /// Moldovan Leu
        /// </summary>
        MDL = 498,
        /// <summary>
        /// Tugrik
        /// </summary>
        MNT = 496,
        /// <summary>
        /// Moroccan Dirham
        /// </summary>
        MAD = 504,
        /// <summary>
        /// Mozambique Metical
        /// </summary>
        MZN = 943,
        /// <summary>
        /// Kyat
        /// </summary>
        MMK = 104,
        /// <summary>
        /// Namibia Dollar
        /// </summary>
        NAD = 516,
        /// <summary>
        /// Nepalese Rupee
        /// </summary>
        NPR = 524,
        /// <summary>
        /// Cordoba Oro
        /// </summary>
        NIO = 558,
        /// <summary>
        /// Naira
        /// </summary>
        NGN = 566,
        /// <summary>
        /// Rial Omani
        /// </summary>
        OMR = 512,
        /// <summary>
        /// Pakistan Rupee
        /// </summary>
        PKR = 586,
        /// <summary>
        /// Balboa
        /// </summary>
        PAB = 590,
        /// <summary>
        /// Kina
        /// </summary>
        PGK = 598,
        /// <summary>
        /// Guarani
        /// </summary>
        PYG = 600,
        /// <summary>
        /// Sol
        /// </summary>
        PEN = 604,
        /// <summary>
        /// Philippine Peso
        /// </summary>
        PHP = 608,
        /// <summary>
        /// Zloty
        /// </summary>
        PLN = 985,
        /// <summary>
        /// Qatari Rial
        /// </summary>
        QAR = 634,
        /// <summary>
        /// Romanian Leu
        /// </summary>
        RON = 946,
        /// <summary>
        /// Russian Ruble
        /// </summary>
        RUB = 643,
        /// <summary>
        /// Rwanda Franc
        /// </summary>
        RWF = 646,
        /// <summary>
        /// Saint Helena Pound
        /// </summary>
        SHP = 654,
        /// <summary>
        /// Tala
        /// </summary>
        WST = 882,
        /// <summary>
        /// Dobra
        /// </summary>
        STN = 930,
        /// <summary>
        /// Saudi Riyal
        /// </summary>
        SAR = 682,
        /// <summary>
        /// Serbian Dinar
        /// </summary>
        RSD = 941,
        /// <summary>
        /// Seychelles Rupee
        /// </summary>
        SCR = 690,
        /// <summary>
        /// Leone
        /// </summary>
        SLL = 694,
        /// <summary>
        /// Singapore Dollar
        /// </summary>
        SGD = 702,
        /// <summary>
        /// Sucre
        /// </summary>
        XSU = 994,
        /// <summary>
        /// Solomon Islands Dollar
        /// </summary>
        SBD = 090,
        /// <summary>
        /// Somali Shilling
        /// </summary>
        SOS = 706,
        /// <summary>
        /// South Sudanese Pound
        /// </summary>
        SSP = 728,
        /// <summary>
        /// Sri Lanka Rupee
        /// </summary>
        LKR = 144,
        /// <summary>
        /// Sudanese Pound
        /// </summary>
        SDG = 938,
        /// <summary>
        /// Surinam Dollar
        /// </summary>
        SRD = 968,
        /// <summary>
        /// Lilangeni
        /// </summary>
        SZL = 748,
        /// <summary>
        /// Swedish Krona
        /// </summary>
        SEK = 752,
        /// <summary>
        /// WIR Euro
        /// </summary>
        CHE = 947,
        /// <summary>
        /// WIR Franc
        /// </summary>
        CHW = 948,
        /// <summary>
        /// Syrian Pound
        /// </summary>
        SYP = 760,
        /// <summary>
        /// New Taiwan Dollar
        /// </summary>
        TWD = 901,
        /// <summary>
        /// Somoni
        /// </summary>
        TJS = 972,
        /// <summary>
        /// Tanzanian Shilling
        /// </summary>
        TZS = 834,
        /// <summary>
        /// Baht
        /// </summary>
        THB = 764,
        /// <summary>
        /// Pa’anga
        /// </summary>
        TOP = 776,
        /// <summary>
        /// Trinidad and Tobago Dollar
        /// </summary>
        TTD = 780,
        /// <summary>
        /// Tunisian Dinar
        /// </summary>
        TND = 788,
        /// <summary>
        /// Turkish Lira
        /// </summary>
        TRY = 949,
        /// <summary>
        /// Turkmenistan New Manat
        /// </summary>
        TMT = 934,
        /// <summary>
        /// Uganda Shilling
        /// </summary>
        UGX = 800,
        /// <summary>
        /// Hryvnia
        /// </summary>
        UAH = 980,
        /// <summary>
        /// UAE Dirham
        /// </summary>
        AED = 784,
        /// <summary>
        /// US Dollar (Next day)
        /// </summary>
        USN = 997,
        /// <summary>
        /// Peso Uruguayo
        /// </summary>
        UYU = 858,
        /// <summary>
        /// Uruguay Peso en Unidades Indexadas (UI)
        /// </summary>
        UYI = 940,
        /// <summary>
        /// Unidad Previsional
        /// </summary>
        UYW = 927,
        /// <summary>
        /// Uzbekistan Sum
        /// </summary>
        UZS = 860,
        /// <summary>
        /// Vatu
        /// </summary>
        VUV = 548,
        /// <summary>
        /// Bolívar Soberano
        /// </summary>
        VES = 928,
        /// <summary>
        /// Dong
        /// </summary>
        VND = 704,
        /// <summary>
        /// Yemeni Rial
        /// </summary>
        YER = 886,
        /// <summary>
        /// Zambian Kwacha
        /// </summary>
        ZMW = 967,
        /// <summary>
        /// Zimbabwe Dollar
        /// </summary>
        ZWL = 932,
        /// <summary>
        /// Bond Markets Unit European Composite Unit (EURCO)
        /// </summary>
        XBA = 955,
        /// <summary>
        /// Bond Markets Unit European Monetary Unit (E.M.U.-6)
        /// </summary>
        XBB = 956,
        /// <summary>
        /// Bond Markets Unit European Unit of Account 9 (E.U.A.-9)
        /// </summary>
        XBC = 957,
        /// <summary>
        /// Bond Markets Unit European Unit of Account 17 (E.U.A.-17)
        /// </summary>
        XBD = 958,
        /// <summary>
        /// Codes specifically reserved for testing purposes
        /// </summary>
        XTS = 963,
        /// <summary>
        /// The codes assigned for transactions where no currency is involved
        /// </summary>
        XXX = 999,
        /// <summary>
        /// Gold
        /// </summary>
        XAU = 959,
        /// <summary>
        /// Palladium
        /// </summary>
        XPD = 964,
        /// <summary>
        /// Platinum
        /// </summary>
        XPT = 962,
        /// <summary>
        /// Silver
        /// </summary>
        XAG = 961
    }
}

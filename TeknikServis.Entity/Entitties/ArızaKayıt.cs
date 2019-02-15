﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.IdentityModels;
using TeknikServis.Web.UI.Abstracts;

namespace TeknikServis.Entity.Entitties
{
    [Table("ArizaKayitlari")]
    public class ArızaKayıt : BaseEntity<int>
    {

        [Required(ErrorMessage = "Lütfen Açıklama kısmını doldurdunuz.")]
        [DisplayName("Arıza Açıklaması")]
        [StringLength(1000)]
        public string ArızaAcıklaması { get; set; }

        [Required(ErrorMessage = "Adres Alanını doldurunuz.")]
        [DisplayName("Adres Giriniz")]
        [StringLength(500, ErrorMessage = "Adres Alanı max 500 karakter olabilir.")]
        public string Adres { get; set; }
        [DisplayName("Telefon Numarası")]
        public string Telno { get; set; }
        [DisplayName("İletişim Maili")]
        public string Email { get; set; }

        [DisplayName("Enlem Giriniz")]
        public string Enlem { get; set; }
        [DisplayName("Boylam Giriniz ")]
        public string Boylam { get; set; }
  
      

        [DisplayName("Ürün Resmi Ekleyiniz")]
        public string ArızaPath { get; set; }
        //todo view modelyapcaksın bu alanı resim için.
        [DisplayName("Fatura Resmini Ekleyiniz")]
        public string FaturaPath { get; set; }

        public DateTime ArizaOlusturmaTarihi { get; set; } = DateTime.Now;
    //todo çözüldügünde datetime.nowla atarsın otomatik
        public DateTime? ArizaCozulduguTarih { get; set; }
        //default olarak çözülemedi atadık.
        public ArizaDurum ArizaDurumu { get; set; } = ArizaDurum.Cozulemedi;

        //todo otomatik olarak false sen operator sayfasında false olanları getirirsin. eger onaylarsa yeni bir sayfasına true olanları alırsın. ve orda yönlendirmeyi yaparsın. Yerse belki ariza durum a da onaylandi eklenebilir.
        public bool OperatorKabul { get; set; } = false;
        



        [Required]
        public string MusteriId { get; set; }
        public string OperatorId { get; set; }
        public string TeknisyenId { get; set; }

        [ForeignKey("MusteriId")]
        public User Musteri { get; set; }
        [ForeignKey("OperatorId")]
        public User Operator { get; set; }
        [ForeignKey("TeknisyenId")]
        public User Teknisyen { get; set; }
    }
}

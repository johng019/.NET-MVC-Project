using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GolfSrambleWeb.Models
{
    public class Players:PlayerCtxt
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Level Required")]
        public string Level { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }
        public string ImagePath { get; set; }

        //public object TextBox1 { get; set; }
        //public object ListBox1 { get; set; }


        public class IndexViewModel
        {
            public string ItemToAdd { get; set; }

            public List<string> AllItems { get; set; }

            public List<string> SelectedItems { get; set; }
            public void AddItem()

            {

                if (!string.IsNullOrEmpty(ItemToAdd) && !AllItems.Contains(ItemToAdd))

                    AllItems.Add(ItemToAdd);
                ItemToAdd = "";

            }


            public void RemoveSelected()
            {

                AllItems.RemoveAll(item => SelectedItems.Contains(item));

                SelectedItems.Clear();
            }


            public void SortItems()

            {
                AllItems.Sort();

            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Models
{
    [DataContract]
    public enum Category
    {
        [DataMember]
        Jeans,
        [DataMember]
        Shirts,
        [DataMember]
        TShirts,
        [DataMember]
        Shorts,
        [DataMember]
        Shoes,
    }
}

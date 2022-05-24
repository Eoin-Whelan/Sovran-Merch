<template>
    <form id='form' @submit.prevent="submitForm" action="" v-if="show">
      <div>
      <label> Username </label>
      <input v-model="Username" type="text" placeholder="Username" >

      <label> Password </label>
      <input v-model="Password" type="password" placeholder="Password" >

      <label> Confirm Password </label>
      <input v-model="ConfirmPassword" type="password" placeholder="Confirm Password" >
      </div>

      <h3> Contact Information </h3>
      
      <div>
      <label >E-Mail Address </label>
      <input v-model="Email" type="text" placeholder="E-Mail Address" >
      
      <label> First Name </label>
        <input v-model="FirstName" type="text" placeholder="First Name" >
     
      <label> Surname </label>
        <input v-model="Surname" type="text" placeholder="Surname" >
      
      <label> Date of Birth </label>
        <input v-model="DateOfBirth" type="text" placeholder="Date of Birth" >
      
      </div>

      <h3> Address Information </h3>
      
      <div>
      <label>Address Line One </label>
        <input v-model="AddressLineOne" type="text" placeholder="Line One">
      
      <label> Address Line Two </label>
        <input v-model="AddressLineTwo" type="text" placeholder="Line Two">
      
      <label> Address Line Three </label>
        <input v-model="AddressLineThree" type="text" placeholder="Line Three">
      
      <label> County </label>
        <input v-model="County" type="text" placeholder="County">
      
      <label> Postcode </label>
        <input v-model="Postcode" type="text" placeholder="Postcode">
      </div>

      <br>
      <br>
      <h3> Customer Support Information</h3>
      <h4> *This is how your customers can reach you</h4>
      
      <p>
      <label> Support Email </label>
        <input v-model="SupportEmail" type="text" placeholder="Username">
      
      <label> Support Phone </label>
        <input v-model="SupportPhone" type="text" placeholder="Username">
      </p>

      <p>
        <label for="img">Profile Picture:</label>
        <input type="file" id="file" ref="file" v-on:change="onFileSubmit"/>
      </p>
      <p style="color:black" v-if="ShowError">{{ErrorMsg}}</p>
      <p style="color:black" v-if="ShowOutcome">{{Result}}</p>
      <button  type="submit">Submit</button>
    </form>
</template>

<style> 

</style>

<script>
import axios from 'axios';

  export default {
    name: "Registration",
    props: ["show"],
    data() {
      return {

        //  Shared Details
        Username: "",
        Email: "",
        SupportEmail: "",
        SupportPhone: "",
        ProfilePic: "",

        //  New Account
        Password: "",
        ConfirmPassword: "",
        PhoneNumber: "",
        FirstName: "",
        Surname: "",
        DateOfBirth: "",
        AddressLineOne: "",
        AddressLineTwo: "",
        AddressLineThree: "",
        County: "",
        Postcode: "",
        ErrorMsg : "",

        //  New Catalog
        Twitter : "",
        Instagram : "",
        Catalog :{
            ItemName : "",
            ItemPrice : 0,
            ItemQty : {
            S: 1
          },
          ItemDesc: "",
          ItemImg: "",
          IsDeleted : false
        },
        ShowError : false,
        ShowOutcome : false,
        Result : ""

      }
    },
    methods:{
      submitForm(){

      axios({
        headers: {
          //'Content-Type': 'application/json'
          headers: {"Access-Control-Allow-Origin": "*"},

        },
        method: 'POST',
        url: '/RegisterAccount',
        data: {
          NewAccount: {
            Username:                 this.Username,
            Password:                 this.Password,
            MerchantEmail:            this.Email,
            PhoneNumber:              this.PhoneNumber,
            FirstName:                this.FirstName,
            Surname:                  this.Surname,
            DateOfBirth:              this.DateOfBirth,
            MerchantAddressLineOne:   this.AddressLineOne,
            MerchantAddressLineTwo:   this.AddressLineTwo ,
            MerchantAddressLineThree: this.AddressLineThree,
            County:                   this.County,
            Postcode:                 this.Postcode,
            SupportEmail:             this.SupportEmail,
            SupportPhone:             this.SupportPhone,
            ProfileImg:               this.ProfilePic,
          },
          NewCatalog: {
            Username:                 this.Username,
            Email:                    this.Email,
            Instagram:                this.Instagram,
            Twitter:                  this.Twitter,
            ProfileImg:               this.ProfilePic,
            Catalog:                  [ {
              itemName: "Cool shirt", 
              itemPrice: 20.0, 
              itemQty :{
                S: 4
                },
              itemDesc: "I told you it was cool",
              itemImg : "cooljayPeg",
              isDeleted: false
              }  
              ]
          }

        }
        }).then(response => {
          this.success = 'Data Saved';
          this.response = JSON.stringify(response, null,2)
        })
      },
      onFileSubmit(e){
        var files = e.target.files;
        if(!files.length){
          return;
        }

        if(files[0].size > 5242880){
          this.ErrorMsg = "File size too large. Max upload: 5MB";
          this.ShowError = true;
          return;
        }
        this.createImage(files[0])
      },
      createImage(file) {
      var reader = new FileReader();
      reader.onload = (e) => {
        this.ProfilePic = e.target.result;
      };
      reader.readAsDataURL(file);
    },
    }
  }
</script>

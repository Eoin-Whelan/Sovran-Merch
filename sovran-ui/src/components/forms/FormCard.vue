<template>
  <div>
    <div class="columns is-centered">
      <div class="buttons">
        <b-button
          label="Login"
          type="is-primary"
          size="is-medium"
          @click="login = true"
        />
        <b-button
          label="Sign Up"
          type="is-primary"
          size="is-medium"
          @click="registration = true"
        />
      </div>
    </div>

    <b-modal v-model="login" :width="640" scroll="keep">
      <div class="card">
        <div class="card-content">
          <h3><b>Enter Your Account Information</b></h3>
          <div class="field">
            <label class="label">Username</label>
            <div class="control">
              <input class="input" type="text" placeholder="Username" />
            </div>
          </div>

          <div class="field">
            <label class="label">Password</label>
            <div class="control">
              <input class="input" type="password" placeholder="Password" />
            </div>
          </div>
        </div>
      </div>
    </b-modal>

    <b-modal v-model="registration" :width="640" scroll="keep">
      <div class="box">
        <section>
          <b-steps>
            <b-step-item label="Merchant Details" icon="account">
              <b-field label="Username (Max 25 Characters)">
                <b-input
                  size="is-medium"
                  v-model="Username"
                  name="Username"
                  type="text"
                  maxlength="25"
                  minlength="4"
                  placeholder="Username"
                  expanded
                  required
                  @blur="formatUsername"
                ></b-input>
              </b-field>
              <b-field label="Email Address">
                <b-input
                  size="is-medium"
                  v-model="Email"
                  name="Email"
                  type="email"
                  placeholder="Email Address"
                  required
                  expanded
                ></b-input>
              </b-field>
              <b-field label="Phone Number (Optional)">
                <b-input
                  size="is-medium"
                  v-model="PhoneNumber"
                  name="PhoneNumber"
                  type="text"
                  placeholder="08..."
                  maxlength="10"
                  expanded
                ></b-input>
              </b-field>
              <b-field label="Password">
                <b-input
                  size="is-medium"
                  v-model="Password"
                  name="Password"
                  type="password"
                  placeholder="Password"
                  password-reveal
                  expanded
                  required
                ></b-input>
              </b-field>
              <b-field label="Profile Picture (Max 5mb)">
                <input
                  type="file"
                  id="file"
                  ref="file"
                  v-on:change="profileImgSubmit"
                />
              </b-field>
              <b-field label="Date of Birth">
                <b-input
                  size="is-medium"
                  v-model="DateOfBirth"
                  name="DateOfBirth"
                  type="date"
                  placeholder="Date of Birth"
                  required
                ></b-input>
              </b-field>
              <b-field grouped group-multiline label="Full Name">
                <b-input
                  size="is-medium"
                  v-model="FirstName"
                  name="FirstName"
                  type="text"
                  placeholder="First Name"
                  required
                ></b-input>
                <b-input
                  size="is-medium"
                  v-model="Surname"
                  name="Surname"
                  type="text"
                  placeholder="Surname"
                  required
                ></b-input>
              </b-field>
              <b-field label="Address"> </b-field>
              <label
                ><i
                  >Sovran Merch is currently unavailable outside of the Republic
                  of Ireland.</i
                ></label
              >
              <b-input
                size="is-medium"
                v-model="AddressLineOne"
                name="AddressLineOne"
                type="text"
                placeholder="AddressLineOne"
                expanded
                required
              ></b-input>
              <b-input
                size="is-medium"
                v-model="AddressLineTwo"
                name="AddressLineTwo"
                type="text"
                placeholder="AddressLineTwo"
                expanded
              ></b-input>
              <b-input
                size="is-medium"
                v-model="City"
                name="City"
                type="text"
                placeholder="Town/City"
                expanded
                required
              ></b-input>
              <b-field grouped group-multiline>
                <b-input
                  size="is-medium"
                  v-model="Postcode"
                  name="Postcode / Eircode"
                  type="text"
                  placeholder="Postcode"
                ></b-input>
              </b-field>
              <b-field grouped group-multiline label="County">
                <b-select
                  size="is-medium"
                  v-model="County"
                  placeholder="County"
                  required
                >
                  <option value="Antrim">Antrim</option>
                  <option value="Armagh">Armagh</option>
                  <option value="Carlow">Carlow</option>
                  <option value="Cavan">Cavan</option>
                  <option value="Clare">Clare</option>
                  <option value="Cork">Cork</option>
                  <option value="Derry">Derry</option>
                  <option value="Donegal">Donegal</option>
                  <option value="Down">Down</option>
                  <option value="Dublin">Dublin</option>
                  <option value="Fermanagh">Fermanagh</option>
                  <option value="Galway">Galway</option>
                  <option value="Kerry">Kerry</option>
                  <option value="Kildare">Kildare</option>
                  <option value="Kilkenny">Kilkenny</option>
                  <option value="Laois">Laois</option>
                  <option value="Leitrim">Leitrim</option>
                  <option value="Limerick">Limerick</option>
                  <option value="Longford">Longford</option>
                  <option value="Louth">Louth</option>
                  <option value="Mayo">Mayo</option>
                  <option value="Meath">Meath</option>
                  <option value="Monaghan">Monaghan</option>
                  <option value="Offaly">Offaly</option>
                  <option value="Roscommon">Roscommon</option>
                  <option value="Sligo">Sligo</option>
                  <option value="Tipperary">Tipperary</option>
                  <option value="Tyrone">Tyrone</option>
                  <option value="Waterford">Waterford</option>
                  <option value="Westmeath">Westmeath</option>
                  <option value="Wexford">Wexford</option>
                  <option value="Wicklow">Wicklow</option>
                </b-select>
              </b-field>
            </b-step-item>
            <b-step-item label="Support Info" icon="phone">
              <h1>How will your customers reach you?</h1>
              <b-field label="Support Email">
                <b-input
                  v-model="SupportEmail"
                  name="SupportEmail"
                  type="text"
                  placeholder="help@sovran.com"
                  expanded
                  required
                ></b-input>
              </b-field>
              <b-field label="Support Phone Number (Optional)">
                <b-input
                  v-model="SupportPhone"
                  name="SupportPhone"
                  type="text"
                  placeholder=""
                  expanded
                ></b-input>
              </b-field>
            </b-step-item>
            <b-step-item label="First Product" icon="hanger">
              <b-field label="Product Name">
                <b-input
                  v-model="Catalog.ItemName"
                  name="ProductName"
                  type="text"
                  placeholder="Username"
                  expanded
                ></b-input>
              </b-field>
              <b-field label="Tell us about your product:">
                <b-input
                  v-model="Catalog.ItemDesc"
                  name="Password"
                  type="textarea"
                  placeholder="Password"
                  expanded
                ></b-input>
              </b-field>
              <b-field label="Price">
                <b-input
                  v-model="Catalog.ItemPrice"
                  name="Price"
                  type="text"
                  placeholder="First Name"
                ></b-input>
              </b-field>
              <b-field label="Measurements / Quantity"></b-field>
              <b-field
                v-model="beLazy"
                v-for="entry in this.Measurements"
                v-bind:key="entry.Measurement"
              >
                <b-input
                  :lazy="beLazy"
                  v-model="entry[0]"
                  type="text"
                ></b-input>
                <b-input v-model="entry[1]" type="number"></b-input>
              </b-field>
              <b-button @click="addListing">Add Measurement</b-button>

              <b-field label="Product Image">
                <input
                  type="file"
                  id="file"
                  ref="file"
                  v-on:change="productImgSubmit"
                />
              </b-field>
              <b-button @click="register">Finish Registration</b-button>
            </b-step-item>
          </b-steps>
        </section>
        <div class="block"></div>
        <section v-if="success">
          <div class="onboarding" v-if="success">
            <b-field
              label="Registration Successful. Please proceed to Stripe to complete onboarding."
            >
            <b-button label="Redirect" @click="redirect"></b-button>
            </b-field>
          </div>
        </section>
      </div>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  components: {},

  data() {
    return {
      beLazy: true,
      login: false,
      registration: false,
      success: false,

      //  Shared Details
      Username: null,
      Email: null,
      SupportEmail: null,
      SupportPhone: null,
      ProfileImg: null,

      //  New Account
      Password: null,
      ConfirmPassword: null,
      PhoneNumber: null,
      FirstName: null,
      Surname: null,
      DateOfBirth: null,
      AddressLineOne: null,
      AddressLineTwo: null,
      City: null,
      County: null,
      Postcode: null,
      DummyUrl : "https://google.ie/",

      ErrorMsg: "",

      Measurements: [["Enter Size Here", 0]],
      //  New Catalog
      Twitter: "",
      Instagram: "",
      Catalog: {
        ItemName: "",
        ItemPrice: 0,
        ItemQty: [
          {
            Measurement: "Enter Size Here",
            Quantity: 0,
          },
        ],
        ItemDesc: "",
        ItemImg: "",
        IsDeleted: false,
      },
      ShowError: false,
      ShowOutcome: false,
      Result: "",
    };
  },
  methods: {
    confirmRedirect() {
      this.$buefy.dialog.confirm({
        message:
          "You will now be redirected to Stripe Payments for identity verification. Proceed?",
        onConfirm: () => (window.location = this.stripeOnBoardingUrl),
      });
    },

    isRequired(value) {
      return value ? true : "This field is required.";
    },
    formatUsername(e) {
      let re = /[^A-Z0-9_]/gi;
      this.Username = e.target.value.replace(re, "");
    },
    checkIsEmpty() {
      var contents = [
        this.Username,
        this.Password,
        this.Email,
        this.PhoneNumber,
        this.FirstName,
        this.Surname,
        this.DateOfBirth,
        this.AddressLineOne,
        this.AddressLineTwo,
        this.City,
        this.County,
        this.Postcode,
        this.SupportEmail,
        this.SupportPhone,
        this.Catalog.ItemName,
        this.Catalog.ItemPrice,
        this.Catalog.ItemDesc,
      ];

      console.log(JSON.stringify(contents));
    },
    checkPw() {
      return;
    },
    addListing() {
      this.Measurements.push(["", 0]);
    },
    register() {

      axios({
        headers: {
          //'Content-Type': 'application/json'
          headers: { "Access-Control-Allow-Origin": "*" },
        },
        method: "POST",
        url: "/Account/RegisterAccount",
        data: {
          NewAccount: {
            Username: this.Username,
            Password: this.Password,
            MerchantEmail: this.Email,
            PhoneNumber: this.PhoneNumber,
            FirstName: this.FirstName,
            Surname: this.Surname,
            DateOfBirth: this.DateOfBirth,
            MerchantAddressLineOne: this.AddressLineOne,
            MerchantAddressLineTwo: this.AddressLineTwo,
            City: this.City,
            County: this.County,
            Postcode: this.Postcode,
            SupportEmail: this.SupportEmail,
            SupportPhone: this.SupportPhone,
            ProfileImg: this.ProfileImg,
          },
          NewCatalog: {
            Username: this.Username,
            Email: this.SupportEmail,
            Instagram: this.Instagram,
            Twitter: this.Twitter,
            ProfileImg: this.ProfileImg,
            Catalog: [
              {
                itemName: this.Catalog.ItemName,
                itemPrice: this.Catalog.ItemPrice,
                itemQty: Object.fromEntries(this.Measurements),
                itemDesc: this.Catalog.ItemDesc,
                itemImg: this.Catalog.ItemImg,
                isDeleted: false,
              },
            ],
          },
        },
      }).then((response) => {
        if (response.data.result) {
            this.stripeOnBoardingUrl = response.data.stripeOnBoardingUrl;
            this.confirmRedirect()
        }
        else{
          console.log(response)
        }
      });
    },
    profileImgSubmit(e) {
      var files = e.target.files;
      if (!files.length) {
        return;
      }

      if (files[0].size > 5242880) {
        this.ErrorMsg = "File size too large. Max upload: 5MB";
        this.ShowError = true;
        return;
      }
      this.createImage(files[0], "profile");
    },
    productImgSubmit(e) {
      var files = e.target.files;
      if (!files.length) {
        return;
      }

      if (files[0].size > 5242880) {
        this.ErrorMsg = "File size too large. Max upload: 5MB";
        this.ShowError = true;
        return;
      }
      this.createImage(files[0], "");
    },
    createImage(file, location) {
      var reader = new FileReader();
      reader.onload = (e) => {
        if (location === "profile") {
          this.ProfileImg = e.target.result;
        } else {
          this.Catalog.ItemImg = e.target.result;
        }
      };
      reader.readAsDataURL(file);
    },
  },
};
</script>

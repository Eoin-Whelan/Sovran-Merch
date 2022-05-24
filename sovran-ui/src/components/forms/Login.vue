<!--
  Dashboard

-->

<template>
      <div v-if="show" class="card is-centered">
              <div class="container">
          <h3 class="title is-4"><b>Please Enter Your Account Information</b></h3>
              </div>
        <div class="card-content">
          <div class="field">
            <label class="title is-5">Username</label>
            <div class="control">
              <input v-model="username" class="input" type="text" placeholder="Username" required />
            </div>
          </div>

          <div class="field">
            <label class="title is-5">Password</label>
            <div class="control">
              <input v-model="password" class="input" type="password" placeholder="Password" required />
            </div>
          </div>
          <b-button type="is-dark" @click="login">Login</b-button>
        </div>
      </div>
</template>
<style>

</style>
<script>
import axios from 'axios';

  export default {
    name: "Login",
    props: ["show"],
    data() {
      return {
        unauthorized : true,
        username : null,
        password: null,
        invalidLogin : false,
        errorMsg: "Invalid Username/Password Combination. Please try again."
      }
    },
    methods: {
      login(){
        console.log(this.username + this.password);
              axios({
        headers: {
          //'Content-Type': 'application/json'
          headers: {"Access-Control-Allow-Origin": "*"},

        },
        method: 'POST',
        url: '/Account/Login',
        data: {
          username:                 this.username,
          password:                 this.password,
        }
        }).then(response => {
          if(response.data == 1){
            console.log("Success!")
            this.$emit('successfulLogin')
          }
          else{
            this.invalidLogin = true;
          }
        })
      }
    },
  }
</script>

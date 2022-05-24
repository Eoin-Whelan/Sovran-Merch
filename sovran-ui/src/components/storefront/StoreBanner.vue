<template>
<div class="container">
  <div class="columns is-flex is-centered">
    <b-image
      id="profileImg"
      :src="this.profilePic"
      :rounded="true"
      >
      </b-image>
  </div>
<div class="columns is-centered">
<h1 class="title is-centered">{{this.username.toLowerCase()}}</h1>
<!-- <b-button :rounded="true" icon-left="instagram" type="is-warning is-light">@{{}}</b-button> -->
</div>
<div class="block"></div>
<div class="block"></div>
</div>
</template>

<style scoped>
#profileImg{
  max-height: 400;
  max-width: 400;
}
</style>

<script>

export default({
  name: 'StoreBanner',
  components: {
  },
  props: ["profilePic", "username"],
  data () {
    return {
        
    }
  },
  beforeMount() {

  },
  methods: {
    seeInstagram(){

    }
    }
})

</script>
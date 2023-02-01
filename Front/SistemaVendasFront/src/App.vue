

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

<template>
  <div id="app">
    <nav-bar-component />
  </div>
  <router-view />
</template>

<script > 
import NavBarComponent from './components/NavBarComponent.vue';
export default{
  components:{
    NavBarComponent
  }
}
</script>

<style>
.fonteColor{
  color: white;
}
</style>

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

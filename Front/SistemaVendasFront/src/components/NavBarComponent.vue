<template>
  <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

  <nav class="navbar bg-primary navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
    <div class="container-fluid">
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarTogglerDemo01"
        aria-controls="navbarTogglerDemo01"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
            <!-- <span class="material-symbols-outlined" style="font-size: 40px;">
home
</span> -->
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">      
            <router-link class="btn" to="/vendedor/listar">Vendedor</router-link> 
          </li>

          <li class="nav-item">      
            <router-link class="btn" to="/cliente/listar">Cliente</router-link> 
          </li>

          <li class="nav-item">      
            <router-link class="btn" to="/servico/listar">Serviço</router-link> 
          </li>

          <li class="nav-item">      
            <router-link class="btn" to="/pedido/listar">Pedido</router-link> 
          </li>
         
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "NavBarComponent",
};
</script>
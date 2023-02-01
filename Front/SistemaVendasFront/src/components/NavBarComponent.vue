
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
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Vendedor
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>      
                  <router-link class="dropdown-item" to="/vendedor/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/vendedor/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li>

          <li>
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Cliente
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>      
                  <router-link class="dropdown-item" to="/cliente/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/cliente/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li>

          <li>
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Serviço
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>      
                  <router-link class="dropdown-item" to="/servico/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/servico/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li>

          <li>
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Pedido
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>     
                  <router-link class="dropdown-item" to="/pedido/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/pedido/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li>

          <!-- <li>
            <div class="dropdown">
              <button
                class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                Item do Pedido
              </button>
              <ul class="dropdown-menu dropdown-menu-dark">
                <li>      
                  <router-link class="dropdown-item" to="/itemPedido/listar">Listar</router-link> 
                </li>
                <li>
                  <router-link class="dropdown-item" to="/itemPedido/cadastrar">Cadastrar</router-link>
                </li>
              </ul>
            </div>
          </li> -->

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
<style scoped>
router-link {
  color: azure;
}
</style>

<template>
    <h3 class="text-center" style="margin-top: 10px;">CADASTRO DE VENDEDORES</h3>
    <hr />
    <div class="container col-3">
        <div>
            <label class="form-label">Nome</label>
            <input type="text" required v-model="vendedor.nome" class="form-control" placeholder="Nome">
        </div>
        <div>
            <label class="form-label">Login</label>
            <input type="text" required v-model="vendedor.login" class="form-control" placeholder="Login">
        </div>
        <div>
            <label class="form-label">Senha</label>
            <input type="password" required v-model="vendedor.senha" class="form-control" placeholder="Senha">
        </div>
        <button class="btn btn-success" @click="cadastrarVendedor" style="margin-top: 4%">Cadastrar</button>
    </div>
</template>

<script>
import VendedorDataService from '../../services/VendedorDataService';

export default {
    data() {
        return {
            vendedor: {
                nome: '',
                login: '',
                senha: ''
            }
        }
    },
    methods: {
        cadastrarVendedor() {
            var data = {
                nome: this.vendedor.nome,
                login: this.vendedor.login,
                senha: this.vendedor.senha
            };
            VendedorDataService.cadastrar(data).then(() => {
                this.$router.push('listar');
            });
        }
    }
}
</script>
<template>
    <h3 class="text-center" style="margin-top: 10px;">ATUALIZAR CLIENTE</h3>

    <hr />

    <div class="container col-3">
        <div>
            <label class="form-label">Id</label>
            <input type="text" disabled v-model="cliente.id" class="form-control">
        </div>

        <div>
            <label class="form-label">Nome</label>
            <input type="text" required v-model="cliente.nome" class="form-control">
        </div>

        <div>
            <label class="form-label">Login</label>
            <input type="text" v-model="cliente.login" class="form-control" placeholder="login">
        </div>

        <div>
            <label class="form-label">Senha</label>
            <input type="password" v-model="cliente.senha" class="form-control" placeholder="Senha">
        </div>
        
        <button class="btn btn-success" @click="atualizarCliente" style="margin-top: 4%">Atualizar</button>
    </div>
</template>

<script>
import ClienteDataService from '../../services/ClienteDataService';

export default {
    data() {
        return {
            cliente: {}
        }
    },
    methods: {
        obterCliente(id) {
            ClienteDataService.obterPorId(id).then((response) => {
                this.cliente = response.data;
            });
        },
        atualizarCliente() {
            ClienteDataService.atualizar(this.cliente.id, this.cliente).then(() => {
                this.$router.push('listar');
            });
        }
    },
    mounted() {
        this.obterCliente(this.$route.params.id);
    }
}
</script>
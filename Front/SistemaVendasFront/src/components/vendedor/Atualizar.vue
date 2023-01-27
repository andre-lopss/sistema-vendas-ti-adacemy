<template>
    <h3>Atualizar Vendedor</h3>

    <div class="form" style="padding: 1%;">
        <hr/>
        <div class="col-4">
            <div>
                <label class="form-label">Id</label>
                <input type="text" disabled v-model="vendedor.id" class="form-control">
            </div>
            <div>
                <label class="form-label">Nome</label>
                <input type="text" required v-model="vendedor.nome" class="form-control">
            </div>
            <div>
                <label class="form-label">Login</label>
                <input type="text" v-model="vendedor.login" class="form-control" placeholder="login">
            </div>
            <div>
                <label class="form-label">Senha</label>
                <input type="password"  v-model="vendedor.senha" class="form-control">
            </div>
            <button class="btn btn-success" @click="atualizarVendedor" style="margin-top: 4%">Atualizar</button>
        </div>
    </div>
</template>

<script>
import VendedorDataService from '../../services/VendedorDataService';

export default {
    data() {
        return {
            vendedor: {}
        }
    },
    methods:{
        obterVendedor(id){
            VendedorDataService.obterPorId(id)
                .then((response) =>{
                    this.vendedor = response.data;
                });
        },
        atualizarVendedor(){
            VendedorDataService.atualizar(this.vendedor.id, this.vendedor)
                                .then(() => {
                                    this.$router.push('listar');
                                });
        }
    },
    mounted(){
        this.obterVendedor(this.$route.params.id);
    }
}
</script>
<template>
    <h3 class="text-center">ATUALIZAR SERVIÇO</h3>

    <div class="form" style="padding: 1%;">
        <hr/>
        <div class="container col-4">
            <div>
                <label class="form-label">Id</label>
                <input type="text" disabled v-model="servico.id" class="form-control">
            </div>
            <div>
                <label class="form-label">Nome</label>
                <input type="text" required v-model="servico.nome" class="form-control">
            </div>
            <div>
                <label class="form-label">Descrição do serviço:</label>
                <textarea class="form-control" v-model="servico.descricao" rows="3"></textarea>
            </div>
            <button class="btn btn-success" @click="atualizarServico" style="margin-top: 4%">Atualizar</button>
        </div>
    </div>
</template>

<script>
import ServicoDataService from '../../services/ServicoDataService';

export default {
    data() {
        return {
            servico: {}
        }
    },
    methods:{
        obterServico(id){
            ServicoDataService.obterPorId(id)
                .then((response) =>{
                    this.servico = response.data;
                });
        },
        atualizarServico(){
            ServicoDataService.atualizar(this.servico.id, this.servico)
                                .then(() => {
                                    this.$router.push('listar');
                                });
        }
    },
    mounted(){
        this.obterServico(this.$route.params.id);
    }
}
</script>
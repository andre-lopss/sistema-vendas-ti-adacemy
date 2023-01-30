<template>
    <h3 class="text-center">LISTAGEM DE SERVIÇOS</h3>

    <div class="container col-8">
        <hr />
        <table class="table table-striped">
            <thead class="bg-primary thead-dark">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Nome</th>
                    <th scope="col">Descrição</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(servico, index) in servicos" :key="index">
                    <td>{{ servico.id }}</td>
                    <td>{{ servico.nome }}</td>
                    <td>{{ servico.descricao }}</td>
                    <td class="d-flex justify-content-between">
                        <button class="btn btn-success" @click="editarServico(servico.id)">Editar</button>
                        <button class="btn btn-danger" @click="excluirServico(servico)">Excluir</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <router-link class="btn btn-danger" to="/servico/cadastrar">Cadastrar Serviço</router-link>
    </div>
</template>

<script>

import ServicoDataService from '../../services/ServicoDataService';
export default {
    data() {
        return {
            servicos: []
        }
    },
    methods: {
        obterServicos() 
        {
            ServicoDataService.listar()
                .then(response => {
                    this.servicos = response.data;
                });
        }, 
        editarServico(id){
            this.$router.push('/servico/' + id);
        },
        async excluirServico(servico){
            if(confirm(`Tem certeza que deseja excluir o serviço ${servico.nome}?`)){
                await ServicoDataService.deletar(servico.id);
                this.obterServicos();
            }
        }
    },
    mounted(){
        this.obterServicos();
    }
}
</script>
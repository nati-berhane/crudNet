
new Vue({
    el:"#app",
    data:{
        host:"http://localhost:49872/api/todo/",
        newTodo:"",
        todos:[],
        btnClass: "ui large fluid button"

    },

    methods:{
        getAllTodos: function(){
            axios.get(this.host)
            .then(response => {
                this.todos = response.data
            })
        },

        addTodo: function(){
            
            if(this.newTodo.length > 0){
                this.btnClass = "ui large fluid disabled loading button"
                axios.post(this.host, {
                    id:"",
                    todo: this.newTodo,
                    isCompleted: false
                }, {
                    headers:{
                        "Content-Type":"application/json"
                    }
                })
                .then(response => {
                    alert(response.data)
                    this.getAllTodos()
                })
                .catch(error => {
                    alert(error.data)
                })
                .finally(() => {
                    this.btnClass ="ui large fluid button"
                })
            }

        },

        deleteTodo: function(id){
            axios.delete(this.host + "?id=" + id, {
                headers:{
                    "Content-Type":"application/json"
                }
            })
            .then(response => {
                alert(response.data)
                this.getAllTodos()
                
            })
            .catch(error => {
                alert(error.data)
            })
        },

        markTodoComplete: function(todo){
            axios.put(this.host, {
                id: todo.id,
                todo: todo.todo,
                isCompleted: true
            }, {
                headers:{
                    "Content-Type":"application/json"
                }
            })
            .then(response =>{
                alert(response.data)
                this.getAllTodos()
            })
            .catch(error => {
                alert(error.data)
            })
        }
    },

    created(){
        this.getAllTodos()
    }

})

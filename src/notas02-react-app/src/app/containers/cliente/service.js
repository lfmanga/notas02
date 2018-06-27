import axios from 'axios'

const clientes = []
for (let i = 0; i < 100; i++) {
    clientes.push({
        id: i,
        nome: 'cliente ' + i
    })
}
export const fetchAll = () => {
    return axios
        .get('http://localhost:5000/api/cliente')
        .then(response => response.data)
}

export const fetchFilter = (filter) => {
    return new Promise((resolve, reject) => {
        resolve(clientes.filter((v) => v.nome === filter))
    })
}

export const fetchById = (id) => {
    return new Promise((resolve, reject) => {
        resolve(clientes[id])
    })
}
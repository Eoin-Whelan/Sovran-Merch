import axios from "axios"


export function getProducts({ commit }) {
    let url = "https://my-json-server.typicode.com/Nelzio/ecommerce-fake-json/products";
    axios.get(url).then((response) => {
        commit("setProducts", response.data);
    }).catch(error => {
        console.log(error);
    });
}


export function productDetails({ commit }, id) {
    let url = "https://my-json-server.typicode.com/Nelzio/ecommerce-fake-json/products";
    axios.get(url, { params: { id: id } }).then((response) => {
        commit("setProduct", response.data[0]);
    }).catch(function (error) {
        console.log(error);
    });
}
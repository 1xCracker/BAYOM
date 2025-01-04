

function getImageURL(name) {
    return new URL(`../../../bayom.web.client/src/assets/products/${name}`, import.meta.url).href
}
export { getImageURL };

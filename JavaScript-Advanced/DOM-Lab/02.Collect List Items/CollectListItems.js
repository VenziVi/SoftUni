function extractText() {
    let getLiItems = document.querySelectorAll('#items li');
    let getTextArea = document.querySelector('#result');
    let result = '';
    for (const item of getLiItems) {
        result += item.textContent + '\n';
    }
    getTextArea.textContent = result.trim();
}
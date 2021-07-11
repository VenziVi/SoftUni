function extract(content) {
    let extractElement = document.getElementById(content);
    let text = extractElement.textContent;
    let extractedText = text.match(/\([A-Za-z ]+\)/gm)
    let result = extractedText.join('; ');
    return result;
}
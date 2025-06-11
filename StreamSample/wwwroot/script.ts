export { };

const paragraph = document.getElementById('paragraph');
const decoder = new TextDecoder();
const response = await fetch('streamTextSimulator');

for await (const chunk of response.body!) {
    const text = decoder.decode(chunk).split('"')[1];
    paragraph!.innerHTML += text;
}

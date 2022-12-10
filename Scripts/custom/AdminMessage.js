const checkboxSelectAll = document.getElementById('nav-select-all')
const checkboxMessage = document.querySelectorAll('.message-select')
const messageTrash = document.querySelectorAll('.message-trash')
const starNone = document.querySelectorAll('.message-icon')
const starActive = document.querySelectorAll('.message-icon-active')
const boxMessage = document.querySelectorAll('.table')
const buttonDelete = document.querySelector('.nav-message-delete')
const boxListMessage = document.querySelector('.box-list-message')
const listMessage = document.querySelectorAll('.table tr')

function selectAll() {
    checkboxSelectAll.addEventListener('change', (event) => {
        if (event.currentTarget.checked) {
            checkboxMessage.forEach(element => {
                element.checked = true;
                element.parentElement.parentElement.style.backgroundColor = 'rgba(0, 0, 0, 0.4)'
            })
        } else {
            checkboxMessage.forEach(element => {
                element.checked = false;
                element.parentElement.parentElement.style.backgroundColor = 'transparent'
            })
        }
    })
}

function deleteMessage() {
    messageTrash.forEach(element => {
        element.addEventListener('click', () => {
            element.parentElement.parentElement.remove();
        })
    })
}

function starMessage() {
    starNone.forEach(element => {
        element.addEventListener('click', () => {
            element.style.display = 'none';
            element.parentElement.querySelector('.message-icon-active').style.display = 'block';
        })
    })

    starActive.forEach(element => {
    element.addEventListener('click', () => {
        element.style.display = 'none';
        element.parentElement.querySelector('.message-icon').style.display = 'block';
    })
})
}

function selectMessage() {
    checkboxMessage.forEach(element => {
        element.addEventListener('change', () => {
            if (element.checked) {
                element.parentElement.parentElement.style.backgroundColor = 'rgba(0, 0, 0, 0.4)'
            } else {
                element.parentElement.parentElement.style.backgroundColor = 'transparent'
            }
        })
    })
}

function deleteMessageChecked() {
    buttonDelete.addEventListener('click', () => {
        checkboxMessage.forEach(element => {
            if (element.checked) {
                element.parentElement.parentElement.remove()
            }
        })
    })
}

function handleReplyBox() {
    const buttonReply = document.querySelector('.btn-reply')
const replyBox = document.querySelector('.message-home__form')
const deleteBoxReply = document.querySelector('.message-home__delete')

    buttonReply.addEventListener('click', () => {
    replyBox.style.display = 'block'
})

    deleteBoxReply.addEventListener('click', () => {
    replyBox.style.display = 'none'
})
}

function watchMessage() {
    listMessage.forEach(element => {
        element.getElementsByTagName("td")[2].addEventListener('click', () => {
            boxListMessage.style.display = 'none'

            let container = document.querySelector('.content-wrapper')
            container.style.minHeight = '712px'
            let html = ""

            html += `
                <div class="message-home text-white">
                    <nav class="message-home__nav m-3 p-2" style="cursor: pointer;font-size: 1.25em;">
                        <span>
                            <i class="message-home__back fa-solid fa-arrow-left"></i>
                        </span>

                        <span style="font-size: 1.75em;font-weight: 500;">${element.querySelector('.message-title').textContent}</span>
                    </nav>

                    <div class="message-home__main m-3" style="text-align: justify;">
                        <span class="d-block mb-3" style="font-size: 1.25em;">${element.getElementsByTagName("td")[2].textContent}</span>
                        <p style="line-height: 1.5;">${element.querySelector('.message-content').textContent}</p>
                    </div>
                        
                    <div class="message-home__reply position-relative">
                        <button class="btn-reply m-3" style="color: #fff;outline: none;border-radius: 16px;border: 1px solid #fff;background-color: transparent;padding: 8px 16px;">
                            <i class="fa-solid fa-reply"></i>
                            Reply
                        </button>
                                
                        <div class="message-home__form position-absolute" style="width: 400px;top: 0;left: 140px;border-radius: 8px;background-color: #fff;display: none;padding: 8px 16px;">
                            <form action="" method="" id="message-form">
                                <p style="display: block;font-size: 1.25em;font-weight: 500;color:black;">${element.getElementsByTagName("td")[2].textContent}</p>
                                <input type="text" style="width: 100%;padding: 4px 8px;" name="message-home__subject" id="message-home__subject" class="d-block mb-2" placeholder="Subject">
                                <textarea style="width: 100%;padding: 4px 8px" class="text-white mb-2" name="message-home__content" id="message-home__content" cols="30" rows="6" placeholder="Your message"></textarea>
                                <div class="d-flex justify-content-between">
                                    <input type="submit" value="Send" id="message-home__submit" style="border: none;outline: none;border-radius: 4px;background-color: #0b57d0;padding: 8px 16px;" class="text-white">
                                    <span class="message-home__delete" style="color: black;cursor: pointer;padding: 8px;">
                                        <i class="fa-solid fa-trash"></i>
                                    </span>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                `
            container.innerHTML = html

            handleReplyBox()
            backAdminMessage()
        })
        element.getElementsByTagName("td")[3].addEventListener('click', () => {
            boxListMessage.style.display = 'none'

            let container = document.querySelector('.content-wrapper')
            container.style.minHeight = '712px'
            let html = ""

            html += `
                <div class="message-home text-white">
                    <nav class="message-home__nav m-3 p-2" style="cursor: pointer;font-size: 1.25em;">
                        <span>
                            <i class="message-home__back fa-solid fa-arrow-left"></i>
                        </span>

                        <span style="font-size: 1.75em;font-weight: 500;">${element.querySelector('.message-title').textContent}</span>
                    </nav>

                    <div class="message-home__main m-3" style="text-align: justify;">
                        <span class="d-block mb-3" style="font-size: 1.25em;">${element.getElementsByTagName("td")[2].textContent}</span>
                        <p style="line-height: 1.5;">${element.querySelector('.message-content').textContent}</p>
                    </div>
                        
                    <div class="message-home__reply position-relative">
                        <button class="btn-reply m-3" style="color: #fff;outline: none;border-radius: 16px;border: 1px solid #fff;background-color: transparent;padding: 8px 16px;">
                            <i class="fa-solid fa-reply"></i>
                            Reply
                        </button>
                                
                        <div class="message-home__form position-absolute" style="width: 400px;top: 0;left: 140px;border-radius: 8px;background-color: #fff;display: none;padding: 8px 16px;">
                            <form action="" method="" id="message-form">
                                <p style="display: block;font-size: 1.25em;font-weight: 500;color:black;">${element.getElementsByTagName("td")[2].textContent}</p>
                                <input type="text" style="width: 100%;padding: 4px 8px;" name="message-home__subject" id="message-home__subject" class="d-block mb-2" placeholder="Subject">
                                <textarea style="width: 100%;padding: 4px 8px" class="text-white mb-2" name="message-home__content" id="message-home__content" cols="30" rows="6" placeholder="Your message"></textarea>
                                <div class="d-flex justify-content-between">
                                    <input type="submit" value="Send" id="message-home__submit" style="border: none;outline: none;border-radius: 4px;background-color: #0b57d0;padding: 8px 16px;" class="text-white">
                                    <span class="message-home__delete" style="color: black;cursor: pointer;padding: 8px;">
                                        <i class="fa-solid fa-trash"></i>
                                    </span>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                `
            container.innerHTML = html

            handleReplyBox()
            backAdminMessage()
        })
    })
}

function backAdminMessage() {
    const backHome = document.querySelector('.message-home__back')
const messageHome = document.querySelector('.message-home')

    backHome.addEventListener('click', () => {
    //render message
    location.reload()
})
}

selectAll()
deleteMessage()
starMessage()
selectMessage()
deleteMessageChecked()
watchMessage()
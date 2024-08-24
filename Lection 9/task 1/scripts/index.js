const lists = document.querySelectorAll('.list')
const boardCreateBtn = document.querySelector('.button')

function addTask() {
    const addBtn = document.querySelector('.buttons_add-item')
    const delBtn = document.querySelector('.buttons_del-item')

    const cardAddBtn = document.querySelector('.add_button')

    const textarea = document.querySelector('.textarea')
    const form = document.querySelector('.form')

    let value
    
    cardAddBtn.addEventListener('click', () => {
        form.style.display = 'block'
        cardAddBtn.style.display = 'none'
        addBtn.style.display = 'none'

        textarea.addEventListener('input', () => {
            value = event.target.value
 
            if(value) {
                addBtn.style.display = 'block'
            } else {
                addBtn.style.display = 'none'
            }
        })
    })

    delBtn.addEventListener('click', () => {
        textarea.value = ''
        value = ''
        form.style.display = 'none'
        cardAddBtn.style.display = 'flex'
    })

    addBtn.addEventListener('click', () => {
        const newItem = document.createElement('div')
        newItem.classList.add('list_item')
        newItem.draggable = true
        newItem.innerHTML = `${value} `;
        lists[0].append(newItem)
        
        textarea.value = ''
        value = ''
        form.style.display = 'none'
        cardAddBtn.style.display = 'flex'

        dragNdrop()
    })
}

addTask()

function addBoard() {
    const boards = document.querySelector('.boards')
    const board = document.createElement('div')
    board.classList.add('boards_item') 
    board.innerHTML = '<span contenteditable="true" class="title">Enter a name</span> <div class="list"></div>'
    
    boards.append(board)
    changeTitle()
    dragNdrop()

    const allBoardsCount = document.querySelectorAll('.boards_item').length
    if (allBoardsCount == 4) {
        boardCreateBtn.style.display = 'none'
    } else {
        board.append(count)
    }
    
}

boardCreateBtn.addEventListener('click', addBoard)

function changeTitle() {
    const titles = document.querySelectorAll('.title')
    
    titles.forEach( title => {
        title.addEventListener('click', e => e.target.textContent = '')
    })

    dragNdrop()
}

changeTitle()

let draggedItem = null

function dragNdrop() {
    const listsItem = document.querySelectorAll('.list_item')
    const lists = document.querySelectorAll('.list')

    for (let index = 0; index < listsItem.length; index++) {
        const item = listsItem[index]

        item.addEventListener('dragstart', () => {
            draggedItem = item
            setTimeout(() => {
            item.style.display = 'none'
            }, 0)
        })
        item.addEventListener('dragend', () => {
            setTimeout(() => {
                item.style.display = 'block'
                draggedItem = null
            }, 0)
        })

        item.addEventListener('dblclick', () => {
            item.remove() // DELETE
        })

        for (let j = 0; j < lists.length; j++) {
            const list = lists[j]
            
            list.addEventListener('dragover', e => e.preventDefault())

            list.addEventListener('dragenter', function (e) {
                e.preventDefault()
                this.style.backgroundColor = 'rgba(0,0,0,.3)'
            })

            list.addEventListener('dragleave', function(e) {
                this.style.backgroundColor = 'rgba(0,0,0, 0)'
            })

            list.addEventListener('drop', function(e) {
                this.style.backgroundColor = 'rgba(0,0,0, 0)'
                this.append(draggedItem)
            })
        }

    }
}

dragNdrop()
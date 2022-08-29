import { Header } from './componentes/Header';
import {Post} from './componentes/Post';
import { Sidebar } from './componentes/Sidebar';
import  './global.css';

import styles from './App.module.css';



const posts=[
  {
    id:1,
    author :{
      avatarUrl:'https://images.unsplash.com/photo-1587620962725-abab7fe55159?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=50',
      name:'Elizandra Lourenço',
      role:'Desenvolver Full Stack',
    },
    content:[
      {type:'paragraph', content:' Fala galeraa 👋'},
      {type:'paragraph',content:'Acabei de subir mais um projeto no meu portifa. É um projeto que fiz no NLW Return,evento da Rocketseat. O nome do projeto é DoctorCare 🚀'},
      {type:'link', content:'👉 jane.design/doctorcare'},
  
    ],
    publishedAt:new Date('2022-08-15 20:00:00'),

  },

  {
    id:2,
    author :{
      avatarUrl:'https://images.unsplash.com/photo-1587620962725-abab7fe55159?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=50',
      name:'Aniel lopes',
      role:'Desenvolver Full Stack',
    },
    content:[
      {type:'paragraph', content:' Fala galeraa 👋'},
      {type:'paragraph',content:'Acabei de subir mais um projeto no meu portifa. É um projeto que fiz no NLW Return,evento da Rocketseat. O nome do projeto é DoctorCare 🚀'},
      {type:'link', content:'👉 jane.design/doctorcare'},
  
    ],
    publishedAt:new Date('2022-08-16 20:00:00'),

  },
]



export function App() {
  

  return (
    <div>
      <Header />
      <div className={styles.wrapper}>
        <aside>
        <Sidebar />
        </aside>
        <main>
      
          {posts.map((post)=>{ 
            return( <Post
            key={post.id}
            author={post.author}
            content={post.content}
            publishedAt={post.publishedAt}
            />)
          })}
          
          

        </main>
      </div>
    </div>
    
  )
}




import './App.css'
import PaymentList from './components/PaymentList'

function App() {
  console.log(import.meta.env.VITE_API_URL);
  return (
    <>
      <PaymentList></PaymentList>
    </>
  )
}

export default App

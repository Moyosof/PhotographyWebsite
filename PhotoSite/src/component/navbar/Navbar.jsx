import React from 'react'
import { NavLink } from "react-router-dom";


const Navbar = () => {
  return (
    <div>
        
           
            <div className='flex justify-between'>
            <NavLink to='/' className="text-">
                    <h1>LOGO</h1>
                </NavLink>
            <ul className="">
                <NavLink to='/'>
                <li>Photoshoot</li>
                </NavLink>
                <li>Wedding shoot</li>
                <li>Graphic Design</li>
                <li> About us</li>
                <li> Contacts</li>
                <li> Sign up</li>
            </ul>

            </div>

        
        

    </div>
  )
}

export default Navbar
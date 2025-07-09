package com.rogerlopez.examen_programacion_1.controller;

import com.rogerlopez.examen_programacion_1.model.Usuario;
import com.rogerlopez.examen_programacion_1.repository.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;

import jakarta.validation.Valid;

@Controller
public class UsuarioController {

    @Autowired
    private UsuarioRepository usuarioRepository;

    @Autowired
    private PasswordEncoder passwordEncoder;

    @GetMapping("/registro")
    public String mostrarFormularioRegistro(Model model) {
        model.addAttribute("usuario", new Usuario());
        return "registro";
    }

    @PostMapping("/registro")
    public String registrarUsuario(@Valid @ModelAttribute("usuario") Usuario usuario, BindingResult result, Model model) {
        if (usuarioRepository.findByEmail(usuario.getEmail()).isPresent()) {
            result.rejectValue("email", "error.usuario", "El email ya está en uso");
        }
        if (result.hasErrors()) {
            return "registro";
        }
        usuario.setPassword(passwordEncoder.encode(usuario.getPassword()));
        usuarioRepository.save(usuario);
        model.addAttribute("mensaje", "Usuario registrado correctamente");
        return "redirect:/login";
    }
}

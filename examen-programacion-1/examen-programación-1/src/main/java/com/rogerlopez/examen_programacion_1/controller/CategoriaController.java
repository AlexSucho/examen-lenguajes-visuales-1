package com.rogerlopez.examen_programacion_1.controller;

import com.rogerlopez.examen_programacion_1.model.Categoria;
import com.rogerlopez.examen_programacion_1.repository.CategoriaRepository;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;


@Controller
@RequestMapping("/categorias")
public class CategoriaController {

    @Autowired
    private CategoriaRepository categoriaRepository;

    // Listar
    @GetMapping
    public String listarCategorias(Model model) {
        model.addAttribute("categorias", categoriaRepository.findAll());
        return "categorias/listar";
    }

    // Formulario nuevo
    @GetMapping("/nuevo")
    public String mostrarFormularioNuevo(Model model) {
        model.addAttribute("categoria", new Categoria());
        return "categorias/formulario";
    }

    // Guardar
    @PostMapping("/guardar")
    public String guardarCategoria(@Valid @ModelAttribute Categoria categoria, BindingResult result) {
        if (result.hasErrors()) {
            return "categorias/formulario";
        }
        categoriaRepository.save(categoria);
        return "redirect:/categorias";
    }

    // Editar
    @GetMapping("/editar/{id}")
    public String mostrarFormularioEditar(@PathVariable Long id, Model model) {
        Categoria categoria = categoriaRepository.findById(id).orElseThrow();
        model.addAttribute("categoria", categoria);
        return "categorias/formulario";
    }

    // Eliminar
    @GetMapping("/eliminar/{id}")
    public String eliminarCategoria(@PathVariable Long id, RedirectAttributes redirectAttrs) {
        try {
            categoriaRepository.deleteById(id); // O el método que uses
            redirectAttrs.addFlashAttribute("success", "Categoría eliminada correctamente.");
        } catch (DataIntegrityViolationException ex) {
            redirectAttrs.addFlashAttribute("error", "No se puede eliminar la categoría porque tiene productos asociados.");
        }
        return "redirect:/categorias";

    }
}

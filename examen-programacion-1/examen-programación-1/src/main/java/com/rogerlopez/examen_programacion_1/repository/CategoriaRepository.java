package com.rogerlopez.examen_programacion_1.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import com.rogerlopez.examen_programacion_1.model.Categoria;

public interface CategoriaRepository extends JpaRepository<Categoria, Long> {
}
